using AutoMapper;
using BridgeMall.Models.Configuration;
using BridgeMall.Models.CRUD;
using BridgeMall.Models.Data;
using BridgeMall.Models.DbValueTypes;
using BridgeMall.Models.DTOs;
using BridgeMall.Models.Helpers;
using BridgeMall.Models.Relational;
using BridgeMall.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text;
using BridgeMall.Contexts.RDB;

namespace BridgeMall.Services.DB
{
	public partial class AuthService(
		BridgeMallDbContext dbContext,
		IUserService userService,
		ICrud crud,
		IMapper mapper,
		HostUrls hostUrls
	) : IAuthService
	{
		private readonly BridgeMallDbContext _dbContext = dbContext;
		private readonly ICrud _crud = crud;
		private readonly HostUrls _hostUrls = hostUrls;
		private readonly IUserService _userService = userService;
		private readonly IMapper _mapper = mapper;

		public RequestResponse LoginUser(LoginModel loginModel)
		{
			try
			{
				User user = _dbContext.Users.FirstOrDefault(u => u.Email == loginModel.Email)!;
				if (user == null) return new(false, "UserNotFound", null!);

				var password = _dbContext.Passwords.FirstOrDefault(p => p.UserId == user.UserId)!;
				if (!AuthenticationHelper.VerifyPassword(loginModel.Password, password.Hashed, password.Salt)) return new(false, "Wrong password", null!);

				UserToken userToken = _dbContext.UserTokens.FirstOrDefault(ut => ut.UserId == user.UserId)!;
				if (userToken != null)
				{
					var check = IsTokenEmptyOrInvalid(userToken.Token);
					if (check.Success || check.Message.Contains("InvalidToken"))
					{
						var token = GetSecurityToken(user.UserId,  user.Email, loginModel.Password, user.Role, loginModel.RememberMe, "No");
						JwtSecurityTokenHandler tokenHandler = new();
						userToken.ExpiryDate = token.ValidTo;
						userToken.Token = tokenHandler.WriteToken(token);
						userToken.LastModified = DateTime.UtcNow;
						_crud.UpdateEntity<UserToken>(userToken.UserTokenId, userToken);
					}
				}
				else if (userToken == null)
				{
					var token = GetSecurityToken(user.UserId, user.Email, loginModel.Password, user.Role, loginModel.RememberMe, "No");
					JwtSecurityTokenHandler tokenHandler = new();
					userToken = new()
					{
						UserId = user.UserId,
						Token = tokenHandler.WriteToken(token),
						ExpiryDate = token.ValidTo,
						DateCreated = DateTime.UtcNow,
						LastModified = DateTime.UtcNow
					};
					_crud.CreateEntity<UserToken>(userToken.UserTokenId, userToken);
				}

				return new(true, "Login is successful", JsonConvert.SerializeObject(new AuthenticatedModel(user.UserId, userToken.Token, _mapper.Map<UserDTO>(user)))); // AuthenticationHelper.GetRoleType(user.Role))));
			}
			catch (Exception ex)
			{
				return new(false, $"Check database connections: {ex.Message}", null!); ;
			}
		}

		public RequestResponse SignUp(SignUpModel signUpModel)
		{
			if (signUpModel is null) return new(false, "Model is null/empty", JsonConvert.SerializeObject(new ArgumentNullException(nameof(SignUpModel))));

			User user = new()
			{
				UserId = 0,
				Name = signUpModel.Name,
				Email = signUpModel.Email,
				Role = RoleType.User.ToString(),
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow,

				Passwords = null!,
				UserToken = null!,
			};

			Password password = AuthenticationHelper.HashPassword(signUpModel.Password, _dbContext.Passwords.Count() + 1);
			password.UserId = user.UserId;
			password.User = null!;
			password.PastPasswords = JsonConvert.SerializeObject(new ObservableCollection<PastPassword>());

			try
			{
				//_dbContext.Users.Add(user);
				var res = _crud.CreateEntity(user.UserId, user);

				if (!res.Success) return new(res.Success, res.Message, res.Reason);

				user = _dbContext.Users.OrderBy(x => x.UserId).LastOrDefault()!;

				password.UserId = user.UserId;
				_crud.CreateEntity(password.PasswordId, password);

				var login = LoginUser(new()
				{
					Email = signUpModel.Email,
					Password = signUpModel.Password,
					RememberMe = true
				});

				return new(true, "You're all signed up", login.Data);
			}
			catch (Exception ex)
			{
				return new(false, "Sign up failed", $"Details: {ex.Message}");
			}
		}


		public RequestResponse IsTokenEmptyOrInvalid(string token)
		{
			try
			{
				if (token == null || "".Equals(token))
				{
					return new(true, "IsEmpty", null!);
				}

				/***
				 * Make string valid for FromBase64String
				 * FromBase64String cannot accept '.' characters and only accepts stringth whose length is a multitude of 4
				 * If the string doesn't have the correct length trailing padding '=' characters should be added.
				 */
				int indexOfFirstPoint = token.IndexOf('.') + 1;
				string toDecode = token[indexOfFirstPoint..token.LastIndexOf('.')];
				while (toDecode.Length % 4 != 0)
				{
					toDecode += '=';
				}

				//Decode the string
				string decodedString = Encoding.ASCII.GetString(Convert.FromBase64String(toDecode));

				//Get the "exp" part of the string
				Regex regex = MyRegex();
				Match match = regex.Match(decodedString);
				long timestamp = Convert.ToInt64(match.Groups[2].Value);

				DateTime date = new DateTime(1970, 1, 1).AddSeconds(timestamp);
				DateTime compareTo = DateTime.UtcNow;

				int result = DateTime.Compare(date, compareTo);

				return new(result < 0, Convert.ToString((bool)(result < 0)), null!);
			}
			catch (Exception ex)
			{
				return new(true, $"InvalidToken", $"Details: {ex.Message}");
			}
		}

		public SecurityToken GetSecurityToken(int userId, string email, string password, string roleName, bool rememberMe, string paidStatus)
		{
			JwtSecurityTokenHandler tokenHandler = new();
			byte[] tokenKey = Encoding.ASCII.GetBytes("AuthenticationHelper.AuthenticationKey");
			int days = 1;
			if (rememberMe == true) days = 365;

			SecurityTokenDescriptor tokenDescriptor = new()
			{
				Issuer = _hostUrls.Current,
				Audience = _hostUrls.CurrentBase,
				Subject = new ClaimsIdentity(new Claim[]
				{
						new("UserId", userId.ToString()),
						new("Email", email),
						new("Password", password),
						new("Role", roleName),
						new("PaidUser", paidStatus)
				}),
				Expires = DateTime.UtcNow.AddDays(days),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};

			return tokenHandler.CreateToken(tokenDescriptor);
		}

		[GeneratedRegex("(\"exp\":)([0-9]{1,})")]
		private static partial Regex MyRegex();
	}
}
