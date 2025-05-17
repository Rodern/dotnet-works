using BridgeMall.Models.Data;
using Microsoft.IdentityModel.Tokens;

namespace BridgeMall.Services.Interfaces
{
    public interface IAuthService
    {
        SecurityToken GetSecurityToken(int userId, string email, string password, string roleName, bool rememberMe, string paidStatus);
        RequestResponse IsTokenEmptyOrInvalid(string token);
        RequestResponse LoginUser(LoginModel loginModel);
        RequestResponse SignUp(SignUpModel signUpModel);
    }
}
