using BloodBankManagementWebapi.Model;

namespace BloodBankManagementWebapi.ApiModel
{
    public class BloodTransactionModel
    {
        public string? BloodTransactionId { get; set; }
        public string? AccountId { get; set; }
        public string? BloodRequestId { get; set; }
        public string? BloodType { get; set; }
        public int units { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
    }
}
