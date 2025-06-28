using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.DataContracts;
using Webshop.Interfaces.Services;
using Webshop.Models;

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
    public async Task<ActionResult<CustomerViewModel[]>> GetAsync()
    {
        var customers = await _customerService.GetAllAsync();
        var viewModel = Mapper(customers);

        return viewModel;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerViewModel>> GetAsync(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer != null)
        {
            var viewModel = Mapper(customer);
            return Ok(viewModel);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<CustomerViewModel>> PostAsync([FromBody] CreateCustomerModel model)
    {
        var domainModel = Mapper(model);
        var createdModel = await _customerService.CreateAsync(domainModel);
        var viewModel = Mapper(createdModel);

        return Ok(viewModel);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateCustomerModel model)
    {
        var domainModel = Mapper(model);
        await _customerService.UpdateAsync(domainModel);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _customerService.DeleteAsync(id);

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
