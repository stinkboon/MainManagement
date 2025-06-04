using Microsoft.EntityFrameworkCore;
using Webshop.Models; // <- voor toegang tot AppDbContext en Customer

namespace Webshop.Repository
{
    public class CustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository()
        {
            var connectionString = "Host=localhost;Port=5432;Database=WebshopDatabase;Username=postgres;Password=Beenham01";
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            _context = new AppDbContext(optionsBuilder.Options);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer? GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }
    }
}