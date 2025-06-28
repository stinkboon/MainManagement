using Microsoft.EntityFrameworkCore;
using Webshop.Interfaces.Repository;
using Webshop.Models;

namespace Webshop.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer[]> GetAllAsync()
        {
            return await _context.Customers.ToArrayAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var customerToBeDeleted = await GetByIdAsync(id);
            if (customerToBeDeleted != null)
            {
                _context.Customers.Remove(customerToBeDeleted);
                await _context.SaveChangesAsync();
            }
        }
    }
}