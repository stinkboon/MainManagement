using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Webshop.Interfaces.Repository;
using Webshop.Interfaces.Services;
using Webshop.Models;
using BCrypt.Net;

namespace Webshop.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public User? Login(string email, string password)
        {
            var user = _repository.GetByEmail(email);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                user.LastLoginDate = DateTime.UtcNow;
                _repository.UpdateUser(user);
                return user;
            }
            return null;
        }

        public User Register(string email, string password)
        {
            var existing = _repository.GetByEmail(email);
            if (existing != null)
            {
                throw new Exception("Gebruiker bestaat al");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var newUser = new User
            {
                Email = email,
                Password = hashedPassword,
                CreatedDate = DateTime.UtcNow,
                LastLoginDate = DateTime.UtcNow
            };

            return _repository.CreateUser(newUser);
        }

        public User? GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public User GetCurrentUser()
        {
            var contextUser = _httpContextAccessor.HttpContext?.User;

            var userIdClaim = contextUser?.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new UnauthorizedAccessException("User ID not found in token");
            }

            int userid = int.Parse(userIdClaim.Value);

            var userResult = _repository.GetById(userid);
            if (userResult == null)
            {
                throw new NullReferenceException($"User with id {userid} not found");
            }

            return userResult;
        }

        public JwtSecurityToken GetToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ditissupersecretzestienkarakters"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Webshop",
                audience: "WebshopUI",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return token;
        }
        public void GeneratePasswordReset(string email)
        {
            var user = _repository.GetByEmail(email);
            if (user == null)
                throw new Exception("Gebruiker niet gevonden");

            // Genereer token
            var token = Guid.NewGuid().ToString();
            user.ResetToken = token;
            user.ResetTokenExpires = DateTime.UtcNow.AddHours(1);

            _repository.UpdateUser(user);
        }
        public void ResetPassword(string token, string newPassword)
        {
            var user = _repository.GetByResetToken(token);
            if (user == null || user.ResetTokenExpires == null || user.ResetTokenExpires < DateTime.UtcNow)
            {
                throw new Exception("Ongeldige of verlopen reset token");
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            user.ResetToken = null;
            user.ResetTokenExpires = null;

            _repository.UpdateUser(user);
        }


    }
}
