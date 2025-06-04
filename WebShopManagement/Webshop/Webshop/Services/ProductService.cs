using Webshop.Models;
using Webshop.Repository;

namespace Webshop.Services;

public class ProductService
{

    private ProductRepository repository;

    public ProductService()
    {
        repository = new ProductRepository();
    }

    public Product Create(Product product)
    {
        var createdProduct = repository.CreateProduct(product);

        return createdProduct;
    }
}