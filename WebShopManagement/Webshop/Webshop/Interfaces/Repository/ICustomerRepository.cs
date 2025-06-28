using Webshop.Models;

namespace Webshop.Interfaces.Repository;

public interface ICustomerRepository
{
    Task<Customer[]> GetAllAsync();

    Task<Customer?> GetByIdAsync(int id);

    Task<Customer> CreateCustomerAsync(Customer customer);

    Task UpdateCustomerAsync(Customer customer);

    Task DeleteByIdAsync(int id);
}