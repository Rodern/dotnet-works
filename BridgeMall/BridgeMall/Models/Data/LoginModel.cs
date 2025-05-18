using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BridgeMall.Models.Data
{
	[RequiresUnreferencedCode("Necessary because of RangeAttribute usage")]
	public class LoginModel
	{
		public LoginModel()
		{
			Email = string.Empty;
			Password = string.Empty;
			Code = string.Empty;
			RememberMe = false;
		}
		public LoginModel(string email, string password, bool rememberMe = true, string code = "")
		{
			Email = email;
			Password = password;
			RememberMe = rememberMe;
			Code = code;
		}

		[Required(ErrorMessage = "Please provide your valid email"), MaxLength(50),
			RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$", ErrorMessage = "Email must be in such format,'example@gmail.com'")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter your password")]
		public string Password { get; set; }
		public bool RememberMe { get; set; }
		public string Code { get; set; }
	}
}
