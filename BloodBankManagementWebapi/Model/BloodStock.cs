namespace BloodBankManagementWebapi.Model
{
    public class BloodStock
    {
        public string? BloodStockId { get; set; }
        public string? BloodType { get; set; }
        
        public int Units { get; set; }
       public Account? Account { get; set; }
    }
}
