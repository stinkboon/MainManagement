using Webshop.Models;

namespace Webshop.Interfaces.Repository;

public interface IProductRepository
{
    Product[] GetAll();
    Product GetById(int id);
    Product CreateProduct(Product product);

    void UpdateProduct(Product product);

    void DeleteById(int id);

}