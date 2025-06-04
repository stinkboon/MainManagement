using System.Collections.Generic;
using Webshop.Models;

namespace Webshop.MockData
{
    public static class MockCustomerList
    {
        public static List<Customer> GetMockCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Alice",
                    LastName = "Janssen",
                    Email = "alice@example.com",
                    PhoneNumber = "0612345678",
                    Address = "Straat 1, Stad"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Peters",
                    Email = "bob@example.com",
                    PhoneNumber = "0687654321",
                    Address = "Straat 2, Stad"
                }
            };
        }
    }
}