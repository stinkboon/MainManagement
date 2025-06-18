using Webshop.Interfaces.Repository;
using Webshop.Models;
using Webshop.Interfaces.Services;

namespace Webshop.Interfaces.Services;

    public interface IUserService
    {
        User? Login(string email, string password);
    } 