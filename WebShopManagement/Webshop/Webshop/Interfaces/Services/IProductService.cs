using Webshop.Models;

namespace Webshop.Interfaces.Services;

public interface IProductService
{
    Product[] GetAll();

    Product GetProductById(int id);

    Product Create(Product product);

    void Delete(int id);
    
    void Update(Product product);
    
    
}