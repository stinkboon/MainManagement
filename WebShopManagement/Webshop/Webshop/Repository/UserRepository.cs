using Webshop.Interfaces.Repository;
using Webshop.Models;

namespace Webshop.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public User? GetByEmail(string email)
    {
        return _context.Users.SingleOrDefault(x => x.Email == email);
    }

    public User? GetById(int id)
    {
        return _context.Users.SingleOrDefault(x => x.Id == id);
    }

    public User CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var userToBeDeleted = GetById(id);
        if (userToBeDeleted != null)
        {
            _context.Users.Remove(userToBeDeleted);
            _context.SaveChanges();
        }
    }
    
    public User? GetByResetToken(string token)
    {
        return _context.Users.FirstOrDefault(u => u.ResetToken == token);
    }

}