using Webshop.Models;

namespace Webshop.Interfaces.Services;

public interface IUserService
{
    User? Login(string email, string password);
    User? GetByEmail(string email);
    User Register(string email, string password); // ← optioneel, maar nodig als je het gebruikt
}