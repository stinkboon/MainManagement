using Webshop.Models;

namespace Webshop.Interfaces.Repository;

public interface ICustomerRepository
{
    Customer[] GetAll();

    Customer GetById(int id);

     Customer CreateCustomer(Customer customer);

     void UpdateCustomer(Customer customer);

     void DeleteById(int id);

}