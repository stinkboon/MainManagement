using Webshop.Interfaces.Repository;
using Webshop.Interfaces.Services;
using Webshop.Models;

namespace Webshop.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUserService _userService;

    public CustomerService(ICustomerRepository customerRepository, IUserService userService)
    {
        _customerRepository = customerRepository;
        _userService = userService;
    }

    public async Task<Customer[]> GetAsync()
    {
        return await _customerRepository.GetAsync();
    }

    public async Task<Customer> GetAsync(int id)
    {
        return await _customerRepository.GetAsync(id);
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        var userIdFromToken = _userService.GetCurrentUser().Id;
        customer.UserId = userIdFromToken;
        
        var createdCustomer = await _customerRepository.CreateAsync(customer);
        return createdCustomer;
    }

    public async Task DeleteAsync(int id)
    {
        await _customerRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(Customer customer)
    {
        var dbModel = await _customerRepository.GetAsync(customer.Id);

        if (dbModel == null) return; // eventueel: throw new Exception("Customer not found");

        dbModel.FirstName = customer.FirstName;
        dbModel.LastName = customer.LastName;
        dbModel.Email = customer.Email;
        dbModel.PhoneNumber = customer.PhoneNumber;
        dbModel.Address = customer.Address;
        dbModel.City = customer.City;
        dbModel.State = customer.State;
        dbModel.Zip = customer.Zip;

        await _customerRepository.UpdateAsync(dbModel);
    }
}