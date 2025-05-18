using Blazored.LocalStorage;
using BridgeMall.Models.Configuration;
using BridgeMall.Models.Data;
using BridgeMall.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BridgeMall.Authentication
{
	public class CustomAuthenticationStateProvider (
		IAuthService authService,
		IUserService userService, 
		ILocalStorageService localStorageService,
		AppInfo appInfo, 
		IJSRuntime jSRuntime) : AuthenticationStateProvider, IHostEnvironmentAuthenticationStateProvider
	{
		private readonly IAuthService _authService = authService;
		private readonly IUserService _userService = userService;
		private readonly ILocalStorageService _localStorageService = localStorageService;
		private readonly AppInfo _appInfo = appInfo;
		private readonly IJSRuntime JSRuntime = jSRuntime;

		private Task<AuthenticationState>? authenticationState;

		public void SetAuthenticationState(Task<AuthenticationState> authenticationStateTask)
		{
			this.authenticationState = authenticationStateTask;
		}

		public override Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			_ = Authenticate();
			return this.authenticationState ?? Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
		}
		public async void MarkUserAsAuthenticated(string userToken)
		{
			try
			{
				var res = _authService.IsTokenEmptyOrInvalid(userToken);
				if (res.Success == true || userToken == null || userToken == "" || userToken == string.Empty)
				{
					authenticationState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
					NotifyAuthenticationStateChanged(authenticationState);
					return;
				}
				string userEmail = await JSRuntime.InvokeAsync<string>("getEmailFromToken", userToken);

				var user = _userService.GetUserByEmail(userEmail);

				var identity = new ClaimsIdentity(
				[
					new Claim("Token", userToken),
					new Claim("UserId", $"{user.UserId}"),
					new Claim("Email", userEmail),
					new Claim("Role", user.Role)
				], "apiauth_type");

				var currentUser = new ClaimsPrincipal(identity);
				authenticationState = Task.FromResult(new AuthenticationState(currentUser));
				NotifyAuthenticationStateChanged(authenticationState);
			}
			catch (Exception)
			{
				return;
			}
		}

		public async Task<bool> Authenticate(string Token = null!)
		{
			try
			{
				if(Token == null)
				{
					string? encryptedToken = await _localStorageService.GetItemAsStringAsync(_appInfo.TokenKey);
					if (encryptedToken != null)
					{
						Token = await JSRuntime.InvokeAsync<string>("DecodeText", encryptedToken);
					}
				}

				var response = _authService.IsTokenEmptyOrInvalid(Token!);
				if (!response.Success)
				{
					MarkUserAsAuthenticated(Token!);

					return true;
				}

				if (response.Success && response.Message.ToLower() == "true")
				{
					string user = await JSRuntime.InvokeAsync<string>("getUserIdFromToken", Token);
					string userPassword = await JSRuntime.InvokeAsync<string>("getPasswordFromToken", Token);

					var authenticationResponse = _authService.LoginUser(new() {
						Email = await JSRuntime.InvokeAsync<string>("getEmailFromToken", Token),
						Password = userPassword,
						RememberMe = true,
						Code = ""
					});

					if (authenticationResponse.Success)
					{
						var AuthModel = JsonConvert.DeserializeObject<AuthenticatedModel>(authenticationResponse.Data);
						MarkUserAsAuthenticated(AuthModel!.Token);
						return true;
					}
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void MarkUserAsNotAuthenticated()
		{
			_ = _localStorageService.RemoveItemAsync(_appInfo.TokenKey);
			var identity = new ClaimsIdentity();
			var user = new ClaimsPrincipal(identity);
			authenticationState = Task.FromResult(new AuthenticationState(user));
			NotifyAuthenticationStateChanged(authenticationState);
		}
	}
}
