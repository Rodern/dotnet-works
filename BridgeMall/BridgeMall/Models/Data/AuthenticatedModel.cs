

using BridgeMall.Models.DTOs;

namespace BridgeMall.Models.Data
{
	public class AuthenticatedModel
	{
		public AuthenticatedModel(int userId, string token, /*RoleType role = RoleType.User,*/ UserDTO user = null!)
		{
			UserId = userId;
			Token = token;
			//Role = role;
			User = user;
		}
		public int UserId { get; set; }
		public string Token { get; set; }
		//public RoleType Role { get; set; }
        public UserDTO User { get; set; }
    }
}
