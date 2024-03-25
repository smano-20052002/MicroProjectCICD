using System.ComponentModel;

namespace BloodBankManagementWebapi.Model
{
    public class Account
    {

        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long PhoneNumber { get; set; }
        [DefaultValue(0)]
        public int Status { get; set; } = 0;
        //public ICollection<AccountRole> AccountRole { get; }
        
        //public string UserDetailsId { get; set; }
       // public ICollection<AccountUserDetailsAddress> AccountUserDetailsAddresses { get;  }


        public BloodTransaction BloodTransaction { get; }
        public BloodCampBloodBank BloodCampBloodBank { get; }
        public BloodBankBloodStock BloodBankBloodStock { get; }


    }
}
