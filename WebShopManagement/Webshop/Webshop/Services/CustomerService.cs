using Webshop.Models;      // voor Customer model
using Webshop.Repository; // voor CustomerRepository


public class CustomerService
{
    private readonly CustomerRepository _repository;

    public CustomerService()
    {
        _repository = new CustomerRepository(); // handmatig
    }

    public Customer Create(Customer customer)
    {
        _repository.AddCustomer(customer);
        return customer;
    }

    public List<Customer> GetAll()
    {
        return _repository.GetAllCustomers();
    }
}