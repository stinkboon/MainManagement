using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.DataContracts;
using Webshop.Interfaces.Services;
using Webshop.Models;
using Webshop.Services;

namespace Webshop.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService; 
    
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    [HttpGet]
    public ActionResult<CustomerViewModel[]> Get()
    {
        var customers = _customerService.GetAll();
        var viewModel = Mapper(customers);

        return viewModel;
    }

    [HttpGet("{id}")]
    public ActionResult<CustomerViewModel> Get(int id)
    {

        var product = _customerService.GetCustomerById(id);

        if (product != null)
        {
            return Ok(product);
        }

        return NotFound();
    }

    [HttpPost]
    public ActionResult<CustomerViewModel> Post([FromBody] CreateCustomerModel model)
    {

        var domainModel = Mapper(model);
        var createdModel = _customerService.Create(domainModel);
        var viewModel = Mapper(createdModel);

        return Ok(viewModel);
    }

    [HttpPut]
    public ActionResult Update([FromBody] UpdateCustomerModel model)
    {

        var domainModel = Mapper(model);
        _customerService.Update(domainModel);

        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {

        _customerService.Delete(id);

        return Ok();
    }

    private CustomerViewModel[] Mapper(Customer[] model)
    {
        List<CustomerViewModel> customers = new();
        foreach (var customer in model)
        {
            var mappedObject = Mapper(customer);
            customers.Add(mappedObject);
        }
        return customers.ToArray();
    }

    private CustomerViewModel Mapper(Customer model)
    {
        return new CustomerViewModel()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Address = model.Address,
            City = model.City,
            State = model.State,
            Zip = model.Zip,
        };
    }

    private Customer Mapper(CreateCustomerModel model)
    {
        return new Customer()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Address = model.Address,
            City = model.City,
            State = model.State,
            Zip = model.Zip,
        };
    }

    private Customer Mapper(UpdateCustomerModel model)
    {
        return new Customer()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Address = model.Address,
            City = model.City,
            State = model.State,
            Zip = model.Zip,
        };
    }
}