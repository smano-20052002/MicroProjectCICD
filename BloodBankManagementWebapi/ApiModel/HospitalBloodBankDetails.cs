namespace BloodBankManagementWebapi.ApiModel
{
    public class HospitalBloodBankDetails
    {
        public string? Id {  get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public long PhoneNumber { get; set; }
        public string? Location { get; set; }
        public string? GovernmentId { get; set; }
        public string? Document { get; set; }
        public string? DoorNo { get; set; }
        public string? Street { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public int Status { get; set; }

    }
}
