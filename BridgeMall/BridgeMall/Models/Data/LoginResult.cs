using BridgeMall.Models.DTOs;

namespace BridgeMall.Models.Data
{
    public class LoginResult
    {
        public LoginResult() { }
        public string UserId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        //public RoleType Role { get; set; } = RoleType.User;

        public UserDTO User { get; set; } = new UserDTO();
    }
}
