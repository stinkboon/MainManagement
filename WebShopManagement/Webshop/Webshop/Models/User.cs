namespace Webshop.Models;

public class User
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime LastLoginDate { get; set; }
    
    public string? ResetHashCode { get; set; }
    
    public ICollection<Product> Products { get; set; }
    public ICollection<Customer> Customers { get; set; }
    
}