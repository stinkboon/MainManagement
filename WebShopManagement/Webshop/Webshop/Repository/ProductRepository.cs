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

public Product[] GetAll()
{
    return _context.Products.ToArray();
}

public Product GetById(int id)
{
    return _context.Products.Single(x => x.Id == id);
}

public Product CreateProduct(Product product)
{
    _context.Products.Add(product);
    _context.SaveChanges();
    return product;
}

public void UpdateProduct(Product product)
{
    _context.Products.Update(product);
    _context.SaveChanges();
}

public void DeleteById(int id)
{
    var productToBeDeleted = GetById(id);
    _context.Products.Remove(productToBeDeleted);
    _context.SaveChanges();
}
}