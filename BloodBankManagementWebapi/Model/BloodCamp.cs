namespace BloodBankManagementWebapi.Model
{
    public class BloodCamp
    {

        public string? BloodCampId { get; set; }
        public string? BloodCampName { get; set; }
        public string? BloodCampLocation { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
   
        public BloodCampBloodBank? BloodCampBloodBank {  get; }

    }
}
