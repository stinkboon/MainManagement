using Webshop.Interfaces.Repository;
using Webshop.Interfaces.Services;
using Webshop.Models;

namespace Webshop.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer[]> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        var createdCustomer = await _repository.CreateCustomerAsync(customer);
        return createdCustomer;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteByIdAsync(id);
    }

    public async Task UpdateAsync(Customer customer)
    {
        var dbModel = await _repository.GetByIdAsync(customer.Id);

        if (dbModel == null) return; // eventueel: throw new Exception("Customer not found");

        dbModel.FirstName = customer.FirstName;
        dbModel.LastName = customer.LastName;
        dbModel.Email = customer.Email;
        dbModel.PhoneNumber = customer.PhoneNumber;
        dbModel.Address = customer.Address;
        dbModel.City = customer.City;
        dbModel.State = customer.State;
        dbModel.Zip = customer.Zip;

        await _repository.UpdateCustomerAsync(dbModel);
    }
}