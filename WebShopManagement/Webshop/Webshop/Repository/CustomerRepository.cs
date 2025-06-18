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
            
            
        public Customer[] GetAll()
        {
            return _context.Customers.ToArray();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.Single(x => x.Id == id);
        }

        public Customer CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var customerToBeDeleted = GetById(id);
            _context.Customers.Remove(customerToBeDeleted);
            _context.SaveChanges();
        }
    }

}