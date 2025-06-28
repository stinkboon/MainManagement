using Webshop.Models;

namespace Webshop.Interfaces.Services;

public interface IProductService
{
    Task<Product[]> GetAsync();
    Task<Product> GetAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task DeleteAsync(int id);
    Task UpdateAsync(Product product);
}