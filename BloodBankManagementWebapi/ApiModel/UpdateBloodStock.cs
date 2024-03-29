namespace BloodBankManagementWebapi.ApiModel
{
    public class UpdateBloodStock
    {
        public string? BloodStockId { get; set; }
        public string? BloodType { get; set; }

        public int Units { get; set; }
    }
}
