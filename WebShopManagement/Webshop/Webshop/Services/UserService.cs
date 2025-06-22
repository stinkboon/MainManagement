using Webshop.Interfaces.Repository;
using Webshop.Interfaces.Services;
using Webshop.Models;

namespace Webshop.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public User? Login(string email, string password)
    {
        var user = _repository.GetByEmail(email);

        if (user != null && user.Password == password)
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

        var newUser = new User
        {
            Email = email,
            Password = password,
            CreatedDate = DateTime.UtcNow,
            LastLoginDate = DateTime.UtcNow
        };

        return _repository.CreateUser(newUser);
    }

    
    public User? GetByEmail(string email)
    {
        return _repository.GetByEmail(email);
    }
}