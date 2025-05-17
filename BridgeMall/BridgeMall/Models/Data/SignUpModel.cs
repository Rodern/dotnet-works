
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeMall.Models.Data
{
	[RequiresUnreferencedCode("Necessary because of RangeAttribute usage")]
	public class SignUpModel
	{
		public int UserId { get; set; }

		[Required(ErrorMessage = "Email is required."),
			RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$", ErrorMessage = "Email must be in such format,'example@gmail.com'")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Name is required."),
			MinLength(2, ErrorMessage = "Name is too short!"),
			MaxLength(15, ErrorMessage = "Name too long (20 character limit).")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Password is most required."),
			RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d][^\\W_]{5,}$", ErrorMessage = "The password must between 6 to 20 characters having atleast an uppercase and a digit."),
			//MinLength(6, ErrorMessage = "The password must between 6 to 20 characters having atleast an uppercase and a digit."),
			MaxLength(20, ErrorMessage = "The password must between 6 to 20 characters having atleast an uppercase and a digit.")]
		public string Password { get; set; } = null!;

		[Required(ErrorMessage = "Required. Please re-enter password."),
			RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d][^\\W_]{5,}$", ErrorMessage = "The password must between 6 to 20 characters having atleast an uppercase and a digit."),
			//MinLength(6, ErrorMessage = "The password must between 6 to 20 characters having atleast an uppercase and a digit."),
			MaxLength(20, ErrorMessage = "The password must between 6 to 20 characters having atleast an uppercase and a digit.")]
		public string CPassword { get; set; } = null!;
	}
}
