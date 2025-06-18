using Webshop.Interfaces.Repository;
using Webshop.Interfaces.Services;
using Webshop.Models;
using Webshop.Repository;

namespace Webshop.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    
    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }
    

    public Customer[] GetAll()
    {
        return _repository.GetAll();
    }

    public Customer GetCustomerById(int id)
    {
        return _repository.GetById(id);
    }

    public Customer Create(Customer customer)
    {
        var createdCustomer = _repository.CreateCustomer(customer);
        return createdCustomer;
    }

    public void Delete(int id)
    {
        _repository.DeleteById(id);
    }

    public void Update(Customer customer)   
    {
        var dbModel = _repository.GetById(customer.Id);

        dbModel.FirstName = customer.FirstName;
        dbModel.LastName = customer.LastName;
        dbModel.Email = customer.Email;
        dbModel.PhoneNumber = customer.PhoneNumber;
        dbModel.Address = customer.Address;
        dbModel.City = customer.City;
        dbModel.State = customer.State;
        dbModel.Zip = customer.Zip;
        

        _repository.UpdateCustomer(dbModel);
    }
}