namespace BloodBankManagementWebapi.Model
{
    public class Address
    {
        public string? AddressId { get; set; }

        public string? DoorNo { get; set; }
        public string? Street { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

        //public ICollection<AccountUserDetailsAddress> AccountUserDetailsAddresses { get; }
     //   public ICollection<BloodStockRequester> StockRequests { get; }



    }
}
