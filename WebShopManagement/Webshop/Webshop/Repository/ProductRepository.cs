using Microsoft.EntityFrameworkCore;
using Webshop.Interfaces.Repository;
using Webshop.Models;

namespace Webshop.Repository;

public class ProductRepository : IProductRepository
{

    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

public async Task<Product[]> GetAllAsync()
{
    return await _context.Products.ToArrayAsync();
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