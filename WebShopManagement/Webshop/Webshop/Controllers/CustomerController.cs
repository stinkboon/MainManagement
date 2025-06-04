using Microsoft.AspNetCore.Mvc;
using Webshop.Models;         
using Webshop.DataContracts; 


[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _service;

    public CustomerController()
    {
        _service = new CustomerService();
    }

    [HttpPost]
    public ActionResult<CustomerViewModel> Post([FromBody] CreateCustomerModel model)
    {
        var domainModel = new Customer
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Address = model.Address
        };

        var createdModel = _service.Create(domainModel);

        var viewModel = new CustomerViewModel
        {
            Id = createdModel.Id,
            FullName = $"{createdModel.FirstName} {createdModel.LastName}",
            Email = createdModel.Email
        };

        return Ok(viewModel);
    }

    [HttpGet]
    public ActionResult<List<CustomerViewModel>> GetAll()
    {
        var customers = _service.GetAll();

        var viewModels = customers.Select(c => new CustomerViewModel
        {
            Id = c.Id,
            FullName = $"{c.FirstName} {c.LastName}",
            Email = c.Email
        }).ToList();

        return Ok(viewModels);
    }
}