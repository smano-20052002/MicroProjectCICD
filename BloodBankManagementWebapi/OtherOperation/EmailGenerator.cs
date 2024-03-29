using BloodBankManagementWebapi.Model;
using Google.Protobuf;
using Microsoft.AspNetCore.Http.HttpResults;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;

namespace BloodBankManagementWebapi.OtherOperation
{
    public static class EmailGenerator
    {
        public static bool SendEmail(string Username, string Mail, string Password)
        {

            string fromMail = "smano8312@gmail.com";
            string senderPass = "mktt mzmx pasy gdgl";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.To.Add(Mail);
            message.Subject = $"Confidential! New Password for Your {Mail} Accounts";

            message.Body = $"Dear {Username},\r\n\r\nThis is a notification from the management. Your new password for {Mail} accounts has been generated. Please take a moment to update your password.\r\n\r\nNew Password: {Password}\r\n\r\nRemember to change your password promptly for security reasons.\r\n\r\nThank you, Management Team";


            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromMail, senderPass);
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public static bool SendEmail(string Username, string Mail, string Message,string RequestId,string ValidDate)
        {

            string fromMail = "smano8312@gmail.com";
            string senderPass = "mktt mzmx pasy gdgl";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.To.Add(Mail);
            if (Message == "BloodRequestApprove")
            {
                message.Subject = $"Important! Blood Request is approved by management";

                message.Body = $"Dear {Username},\r\n\r\nThis is a notification from the management. Your Blood Request for Id {RequestId} is approved by management.Please check the website and it is valid for date {ValidDate}.\r\n\r\nThank you, Management Team";

            }
            else if (Message == "BloodRequestReject")
            {
                message.Subject = $"Important! Blood Request is rejected by management";

                message.Body = $"Dear {Username},\r\n\r\nThis is a notification from the management. Your Blood Request for Id {RequestId} is rejected by management.Please apply again with correct information.\r\n\r\nThank you, Management Team";

            }


            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromMail, senderPass);
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public static bool SendEmailForAccountApproval(string Name, string Email, string ApprovalStatus)
        {
            string fromMail = "smano8312@gmail.com";
            string senderPass = "mktt mzmx pasy gdgl";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.To.Add(Email);
            if (ApprovalStatus == "AccountApprove")
            {
                message.Subject = $"Important! Account is approved by management";

                message.Body = $"Dear {Name},\r\n\r\nThis is a notification from the management. Your Account is approved by management.Please check the website .\r\n\r\nThank you, Management Team";

            }
            else if (ApprovalStatus == "AccountReject")
            {
                message.Subject = $"Important! Account is rejected by management";

                message.Body = $"Dear {Name},\r\n\r\nThis is a notification from the management. Your Account is rejected by management.Please check the website .\r\n\r\nThank you, Management Team";

            }


            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromMail, senderPass);
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public static void SendEmailForAcceptRequest(string Email, string BloodRequestId, Account account, Address address,UserDetails userdetails)
        {
            string fromMail = "smano8312@gmail.com";
            string senderPass = "mktt mzmx pasy gdgl";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.To.Add(Email);
                message.Subject = $"Important! Your Blood Request is accept by {account.Name}";

                message.Body = $"Dear {account.Name},\r\n\r\nYour request is accepted by {account.Name}-{userdetails.Location}.Please check the bank and collect the blood. \nAddress :\n{address.DoorNo},\n{address.Street},\n{address.Area},\n{address.City},\n{address.State}-{address.PostalCode}.\r\n\r\nThank you, Management Team";


            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromMail, senderPass);
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(message);
                return;
            }
            catch (Exception ex)
            {
                return;
            }

        }
    }
}
