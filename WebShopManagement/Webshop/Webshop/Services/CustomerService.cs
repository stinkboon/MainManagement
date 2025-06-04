using Webshop.Models;      
using Webshop.Repository; 


public class CustomerService
{
    private readonly CustomerRepository _repository;

    public CustomerService()
    {
        _repository = new CustomerRepository();
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