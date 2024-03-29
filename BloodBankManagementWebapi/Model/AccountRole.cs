namespace BloodBankManagementWebapi.Model
{
    public class AccountRole
    {
        public string? AccountRoleId { get; set; }
        public Account? Account { get; set; }
        public Role? Role { get; set; }
    }

}
