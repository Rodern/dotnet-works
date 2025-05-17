using BridgeMall.Models.Data;
using BridgeMall.Models.Helpers;
using BridgeMall.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Farmlink.SHARED.Areas.Controllers.API
{
	[Route("api")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpGet]
		[Route("generateGuid")]
		public IActionResult GenerateGuid()
		{
			return Ok(AuthenticationHelper.GenerateGuidString());
		}

		[HttpGet("isTokenEmptyOrInvalid")]
		public IActionResult IsEmptyOrInvalid(string token)
		{
			return Ok(_authService.IsTokenEmptyOrInvalid(token));
		}

		[HttpPost("signup")]
		public IActionResult SignUp(SignUpModel signUpModel)
		{
			return Ok(_authService.SignUp(signUpModel));
		}

		[HttpPost("login")]
		public IActionResult Login(LoginModel loginModel)
		{
			return Ok(_authService.LoginUser(loginModel));
		}
	}
}
