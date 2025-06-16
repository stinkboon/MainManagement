using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.DataContracts;
using Webshop.Models;
using Webshop.Services;

namespace Webshop.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet]
    public ActionResult<ProductViewModel[]> Get()
    {
        var service = new ProductService();
        var products = service.GetAll();
        var viewModel = Mapper(products);

        return viewModel;
    }

    [HttpGet("{id}")]
    public ActionResult<ProductViewModel> Get(int id)
    {
        var service = new ProductService();

        var product = service.GetProductById(id);

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
        var createdModel = service.Create(domainModel);
        var viewModel = Mapper(createdModel);

        return Ok(viewModel);
    }

    [HttpPut]
    public ActionResult Update([FromBody] UpdateProductModel model)
    {
        var service = new ProductService();

        var domainModel = Mapper(model);
        service.Update(domainModel);

        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var service = new ProductService();

        service.Delete(id);

        return Ok();
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

    private Product Mapper(UpdateProductModel model)
    {
        return new Product()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Stock = model.Stock,
            DiscountPercentage = model.DiscountPercentage
        };
    }
}