using BloodBankManagementWebapi.Model;

namespace BloodBankManagementWebapi.ApiModel
{
    public class ForgetPasswordMessage
    {
        public bool EmailExists { get; set; }
        public bool SendMail { get; set; }
    }
    public class ChangePasswordMessage
    {
        public bool EmailExists { get; set; }
        public bool Passcheck { get; set; }

    }
    public class CheckBloodRequestStatusMessage
    {
        public bool IdExists { get; set; }
        public string? Status { get; set; }
        public List<BloodBankStock>? bloodRequestBloodBank { get; set; }
    }
    public class ApproveOrRejectReturnMessage()
    {
        public bool ValidEmail {  get; set; }
        public bool IdExists { get; set; }
        public bool ChangeStatus { get; set; }
    }
    public class AuthMessageModel
    {
        public string? AccountApproval { get; set; }
        public bool AccountExists { get; set; }
        public bool PasswordStatus { get; set; }
        public string? Token { get; set; }

    }
    public class SignUpMessageModel
    {
        public bool EmailExists { get; set; }
        public bool MobileNumberExists { get; set; }
        
    }
}
