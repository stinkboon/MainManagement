using Webshop.Models;

namespace Webshop.Interfaces.Repository;

public interface ICustomerRepository
{
    Task<Customer[]> GetAsync();

    Task<Customer?> GetAsync(int id);

    Task<Customer> CreateAsync(Customer customer);

    Task UpdateAsync(Customer customer);

    Task DeleteAsync(int id);
}