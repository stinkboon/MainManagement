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
    public ProductListViewModel Get()
    {
        return MockProductList.ProductList;
    }
    
    [HttpGet("{id}")]
    public ActionResult<ProductListViewModel>? Get(int id)
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





