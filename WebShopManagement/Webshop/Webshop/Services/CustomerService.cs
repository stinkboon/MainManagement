using Webshop.Models;
using Webshop.Repository;

namespace Webshop.Services;

public class CustomerService
{
    private readonly CustomerRepository repository;

    public CustomerService()
    {
        repository = new CustomerRepository();
    }

    public Customer[] GetAll()
    {
        return repository.GetAll();
    }

    public Customer GetCustomerById(int id)
    {
        return repository.GetById(id);
    }

    public Customer Create(Customer customer)
    {
        var createdCustomer = repository.CreateCustomer(customer);
        return createdCustomer;
    }

    public void Delete(int id)
    {
        repository.DeleteById(id);
    }

    public void Update(Customer customer)
    {
        var dbModel = repository.GetById(customer.Id);

        dbModel.FirstName = customer.FirstName;
        dbModel.LastName = customer.LastName;
        dbModel.Email = customer.Email;
        dbModel.PhoneNumber = customer.PhoneNumber;
        dbModel.Address = customer.Address;
        dbModel.City = customer.City;
        dbModel.State = customer.State;
        dbModel.Zip = customer.Zip;
        

        repository.UpdateCustomer(dbModel);
    }
}