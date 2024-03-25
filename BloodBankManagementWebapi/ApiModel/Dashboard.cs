namespace BloodBankManagementWebapi.ApiModel
{
    public class Dashboard
    {
      
        public int Hospital { get; set; }
        public int Donor { get; set; }
        public int Bloodcamp { get; set; }
        public int BloodBank { get; set; }
        public int BloodRequest { get; set; }
        public int HospitalRequest { get; set; }
        public int BloodBankPendingRequest { get; set; }
        public int DonorPendingRequest { get; set; }
        public int HospitalPendingRequest { get; set; }
        public int PendingBloodRequest { get; set; }
    }
    public class BloodDashboard
    {
        public int Apositive { get; set; }
        public int Bpositive {  get; set; }
        public int Opositive { get; set; }
        public int ABpositive { get; set; }
        public int Anegative { get; set; }
        public int Bnegative { get; set; }
        public int Onegative { get; set; }
        public int ABnegative { get; set; }
    }
}
