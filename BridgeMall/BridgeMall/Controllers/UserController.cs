using AutoMapper;
using BridgeMall.Models.DTOs;
using BridgeMall.Models.Relational;
using BridgeMall.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BridgeMall.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		private readonly IMapper _mapper;
		public UserController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		[HttpGet("getAllUsers")]
		public IActionResult GetAllUsers()
		{
			var users = _userService.GetUsers();
			return Ok(users);
		}

		[HttpGet("getUsers")]
		public IActionResult GetUsers(string? searchString)
		{
			var users = _userService.GetUsers(searchString);
			return Ok(users);
		}

		[HttpGet("getUser/{userId}")]
		public IActionResult GetUser(int userId)
		{
			var user = _userService.GetUser(userId);
			if (user == null)
			{
				return NotFound();
			}
			return Ok(user);
		}

		[HttpPost("createUser")]
		public IActionResult CreateUser([FromBody] UserDTO userDTO)
		{
			if (userDTO == null)
			{
				return BadRequest("User cannot be null");
			}
			return Ok(_userService.CreateUser(_mapper.Map<User>(userDTO)));
		}

		[HttpPut("updateUser")]
		public IActionResult UpdateUser(UserDTO userDTO)
		{
			if (userDTO == null)
			{
				return BadRequest("User cannot be null");
			}
			return Ok(_userService.UpdateUser(_mapper.Map<User>(userDTO)));
		}

		[HttpDelete("deleteUser/{userId}")]
		public IActionResult DeleteUser(int userId)
		{
			return Ok(_userService.DeleteUser(userId));
		}
	}
}
