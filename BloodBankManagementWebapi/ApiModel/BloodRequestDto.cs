using System.ComponentModel;

namespace BloodBankManagementWebapi.ApiModel
{
    public class BloodRequestDto
    {
        public string? BloodRequestId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public int Units { get; set; }

        public long PhoneNumber { get; set; }
        public string? BloodType { get; set; }
        public int Age { get; set; }

        public string? Location { get; set; }
        public long AadhaarNumber { get; set; }
        [DefaultValue(null)]
        public string? ValidTime { get; set; }
        [DefaultValue(0)]
        public int Status { get; set; } = 0;
    }
}
