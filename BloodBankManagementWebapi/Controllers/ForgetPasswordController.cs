using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.OtherOperation;
using Microsoft.AspNetCore.Http;
using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgetPasswordController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ForgetPasswordController(AppDbContext context)
        {
            _context= context;
        }
        [HttpPost]
        public IActionResult SendMailForPassword([FromBody] EmailClass Mail)
        {
            ForgetPasswordMessage message = null;
            if (!_context.Account.Any(s => s.Email == Mail.Email))
            {
                message = new ForgetPasswordMessage
                {
                    EmailExists = false,
                    SendMail = false
                };
                return Ok(message);
            }
            string Password = RandomPasswordGeneration.RandomPasswordGenerator();
            Account olduser = _context.Account.Where(s => s.Email == Mail.Email).FirstOrDefault()!;

            olduser.Password = SHA256Encrypt.ComputePasswordToSha256Hash(Password);
            //_context.Entry(olduser).State = EntityState.Detached;
            _context.Account.Update(olduser);
            _context.SaveChangesAsync();
            if (EmailGenerator.SendEmail(olduser.Name, olduser.Email, Password))
            {
                message = new ForgetPasswordMessage
                {
                    EmailExists = true,
                    SendMail = true
                };
                return Ok(message);
            }
            else
            {
                message = new ForgetPasswordMessage
                {
                    EmailExists = true,
                    SendMail = false
                };
                return Ok(message);
            }
        }
    }
}
