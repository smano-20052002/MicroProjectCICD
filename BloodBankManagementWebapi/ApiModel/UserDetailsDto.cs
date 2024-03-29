namespace BloodBankManagementWebapi.ApiModel
{
    public class UserDetailsDto
    {
        public string? UserDetailsId { get; set; }

        public int Age { get; set; }
        public string? BloodType { get; set; }

        public string? Location { get; set; }

        public string? GovernmentId { get; set; }

        public string? Document { get; set; }

        public long AadhaarNumber { get; set; }
    }
}
