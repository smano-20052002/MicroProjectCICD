namespace BloodBankManagementWebapi.Model
{
    public class BloodTransaction
    {
        public string? BloodTransactionId { get; set; }
        public string? AccountId { get; set; }
        public Account Account { get; set; }
        public string? BloodRequestId { get; set; }
        public BloodRequest BloodRequest { get; set; }
        public string? BloodType { get; set; }

        public int units { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
    }
}
