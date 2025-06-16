using Microsoft.EntityFrameworkCore;
using Webshop.Models; // <- voor toegang tot AppDbContext en Customer

namespace Webshop.Repository
{
    public class CustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository()
        {
            var connectionString =
                "Host=localhost;Port=5432;Database=WebshopDatabase;Username=postgres;Password=Beenham01";
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            _context = new AppDbContext(optionsBuilder.Options);
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