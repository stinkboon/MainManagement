export interface CreateCustomerModel {
    id: number
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
    address: {
        street: string;
        city: string;
        state: string;
        zipCode: string;
    };
    dateOfBirth?: Date; // Optional field
    isActive?: boolean; // Optional field
}