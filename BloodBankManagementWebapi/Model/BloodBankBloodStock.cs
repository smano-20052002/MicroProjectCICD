namespace BloodBankManagementWebapi.Model
{
    public class BloodBankBloodStock
    {
        public string? BloodBankBloodStockId { get; set; }
        public BloodStock? BloodStock { get; set; }
        public Account? Account { get; set; }
    }
}
