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

		[Required(ErrorMessage = "Please provide your valid email"), MaxLength(50)]
		public string Email { get; set; }
		[Required(ErrorMessage = "Please enter your password")]
		public string Password { get; set; }
		public bool RememberMe { get; set; }
		public string Code { get; set; }
	}
}
