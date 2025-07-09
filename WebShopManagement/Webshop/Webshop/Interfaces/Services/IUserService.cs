using System.IdentityModel.Tokens.Jwt;
using Webshop.Models;

namespace Webshop.Interfaces.Services
{
    public interface IUserService
    {
        User? Login(string email, string password);
        User? GetByEmail(string email);
        User Register(string firstName, string lastName, string email, string password);
        User GetCurrentUser();

        JwtSecurityToken GetToken(User user); 
        
        void GeneratePasswordReset(string email);
        void ResetPassword(string token, string password);

    }
}