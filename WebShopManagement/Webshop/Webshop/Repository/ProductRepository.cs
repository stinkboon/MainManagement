using Microsoft.EntityFrameworkCore;
using Webshop.Models;

namespace Webshop.Repository;

public class ProductRepository
{

    private readonly AppDbContext _context;

    public ProductRepository()
    {
        var connectionString = "Host=localhost;Port=5432;Database=WebshopDatabase;Username=postgres;Password=Beenham01";
        
        var optionsBuilder  = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        
        _context = new AppDbContext(optionsBuilder.Options);
    }
    
    public Product CreateProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();

        return product;

    }
    
    
    public ProductRepository GetProductById(int id)
    {
        return null;
    }
        
}