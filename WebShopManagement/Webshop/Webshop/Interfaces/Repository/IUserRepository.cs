using Webshop.Models;

namespace Webshop.Interfaces.Repository;

public interface IUserRepository
{
        User? GetByEmail(string email);
        User? GetById(int id);
        User CreateUser(User user);
        void UpdateUser(User user);
        void Delete(int id);
        
        User? GetByResetToken(string token);

}