namespace BloodBankManagementWebapi.Model
{
    public class AccountUserDetailsAddress
    {
        public string? AccountUserDetailsAddressId {  get; set; }
        public Account? Account {  get; set; }
        public UserDetails? UserDetails { get; set; }
        public Address? Address { get; set; }


    }
}
