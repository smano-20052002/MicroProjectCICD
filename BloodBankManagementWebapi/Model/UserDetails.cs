namespace BloodBankManagementWebapi.Model
{
    public class UserDetails
    {
        public string? UserDetailsId { get; set; }

        public int Age { get; set; }    
        public string? BloodType { get; set; }

        public string? Location {  get; set; }

        public string? GovernmentId {  get; set; }
        
        public byte[] Document { get; set; }

        public long AadhaarNumber { get; set; }

        public int rolestatus { get; set; }
      //  public ICollection<BloodStockRequester> StockRequests { get; }



        // public ICollection<AccountUserDetailsAddress> AccountUserDetailsAddresses { get; }


    }
}
