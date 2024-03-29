namespace BloodBankManagementWebapi.Model
{
    public class BloodStockRequester
    {
        public string? BloodStockRequesterId {  get; set; }

        public BloodRequest BloodRequest { get; set; }

        public Account Account { get; set; }

        public UserDetails UserDetails { get; set; }

        public Address Address { get; set; }    

    }
}
