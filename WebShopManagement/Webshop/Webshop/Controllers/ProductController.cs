using Microsoft.AspNetCore.Mvc;
using Webshop.DataContracts;
using Webshop.MockData;
using Webshop.Models;
using Webshop.Services;

namespace Webshop.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public ProductViewModel[] GetAll()
    {
        var service = new ProductService();
        var products = service.GetAll();
        var viewModel = Mapper(products);
        return viewModel;
    }
    
    [HttpGet("{id}")]
    public ActionResult<ProductListViewModel>? GetProduct(int id)
    {
        var product = MockProductList.ProductList.Products.SingleOrDefault(x => x.Id == id);

        if (id == 3) // = verboden toegang
        {
            return Unauthorized();
        }
        
        if (product != null)
        {
            return Ok(product);
        }
        
        return NotFound();
    }

    [HttpPost]
    public ActionResult<ProductViewModel> Post([FromBody] CreateProductModel model)
    {
        var service = new ProductService();

        var domainModel = Mapper(model);
        var createdmodel = service.Create(domainModel);
        var viewmodel = Mapper(createdmodel);
            
        
        return Ok(viewmodel);
    }

    private ProductViewModel[] Mapper(Product[] model)
    {
        List<ProductViewModel> products = new();
        foreach (var product in model)
        {
            var mappedObject = Mapper(product);
            products.Add(mappedObject);
        }
        return products.ToArray();
    }
    
    
    private ProductViewModel Mapper(Product model)
    {
        return new ProductViewModel()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Stock = model.Stock,
            DiscountPercentage = model.DiscountPercentage
        };
    }
    private Product Mapper(CreateProductModel model)
    {
        return new Product()
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Stock = model.Stock,
            DiscountPercentage = model.DiscountPercentage
        };
    }
}





