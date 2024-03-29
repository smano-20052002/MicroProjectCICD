using BloodBankManagementWebapi.Model;

namespace BloodBankManagementWebapi.ApiModel
{
    public class RegisterModel
    {
        
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public long PhoneNumber { get; set; }
        public string? Role { get; set; }
        public int Age { get; set; }
        public string? BloodType { get; set; }

        public string? Location { get; set; }

        public string? GovernmentId { get; set; }

        public string? Document { get; set; }

        public long AadhaarNumber { get; set; }
        public string? DoorNo { get; set; }
        public string? Street { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

    }
}
