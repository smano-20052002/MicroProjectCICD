namespace BloodBankManagementWebapi.Model
{
    public class BloodCampBloodBank
    {
        public string? BloodCampBloodBankId { get; set; }
        public BloodCamp? BloodCamp { get; set; }
        public Account? Account { get; set; }
    }
}
