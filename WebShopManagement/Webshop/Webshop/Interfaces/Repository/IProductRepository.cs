using Webshop.Models;

namespace Webshop.Interfaces.Repository;

public interface IProductRepository
{
    Task<Product[]> GetAsync();
    Task<Product> GetAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
    

}