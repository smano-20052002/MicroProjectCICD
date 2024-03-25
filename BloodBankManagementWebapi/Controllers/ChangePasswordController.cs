using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.Model;
using BloodBankManagementWebapi.OtherOperation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodBankManagementWebapi.ApiModel;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePasswordController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ChangePasswordController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult ChangePassword([FromBody] ChangePassword changePassword)
        {
            ChangePasswordMessage changePasswordMessage;
            if (_context.Account.Any(user => user.Email == changePassword.Email))
            {
                Account olduser = _context.Account.Where(s => s.Email == changePassword.Email).FirstOrDefault()!;
                if (olduser.Password == SHA256Encrypt.ComputePasswordToSha256Hash(changePassword.OldPassword))
                {
                    olduser.Password = SHA256Encrypt.ComputePasswordToSha256Hash(changePassword.NewPassword);


                    _context.Account.Update(olduser);
                    _context.SaveChanges();
                    changePasswordMessage = new ChangePasswordMessage()
                    {
                        EmailExists = true,
                        Passcheck = true
                    };
                    return Ok(changePasswordMessage);
                }
                else
                {
                    changePasswordMessage = new ChangePasswordMessage()
                    {
                        EmailExists = true,
                        Passcheck = false
                    };
                    return Ok(changePasswordMessage);
                }

            }
            else
            {
                changePasswordMessage = new ChangePasswordMessage()
                {
                    EmailExists = false,
                    Passcheck = false
                };
                return Ok(changePasswordMessage);
            }

        }
    }

}
