namespace Webshop.DataContracts;

    public class CustomerViewModel
    {
        public int Id { get; set; }
        
        public required string FirstName { get; set; }
        
        public required string LastName { get; set; }
        
        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }
        
        public required string Address { get; set; }
        
        public required string City { get; set; }
        
        public required string State { get; set; }
        
        public required string Zip { get; set; }
    }
    