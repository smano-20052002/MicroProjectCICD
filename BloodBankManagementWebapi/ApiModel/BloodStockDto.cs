namespace BloodBankManagementWebapi.ApiModel
{
    public class BloodStockDto
    {
        public string? BloodStockId { get; set; }
        public string? BloodType { get; set; }

        public int Units { get; set; }

        public string? AccountId { get; set; }
    }
}
