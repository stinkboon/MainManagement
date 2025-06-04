namespace Webshop.DataContracts;

public class CreateCustomerModel {
    
        public required string FirstName { get; set; }
        
        public required string LastName { get; set; }
        
        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }
        
        public required string Address { get; set; }
    }
    