using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.OtherOperation;
using System.Security.Claims;
using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.Model;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AppDbContext _context;
        //private readonly IConfiguration _configuration;
        public RegisterController(AppDbContext context)
        {
            _context = context;
        //    _configuration = configuration;
        }
        [HttpPost]

        public IActionResult PostUser(RegisterModel registerUser)
        {
            SignUpMessageModel message = null;
            if (_context.Account.Any(s => s.Email == registerUser.Email) || _context.Account.Any(s => s.PhoneNumber == registerUser.PhoneNumber))
            {
                if (_context.Account.Any(s => s.Email == registerUser.Email) && _context.Account.Any(s => s.PhoneNumber == registerUser.PhoneNumber))
                {
                    message = new SignUpMessageModel()
                    {
                        EmailExists = true,
                        MobileNumberExists = true
                    };
                    return Ok(message);
                }
                if (_context.Account.Any(s => s.PhoneNumber == registerUser.PhoneNumber))
                {
                    message = new SignUpMessageModel()
                    {
                        EmailExists = false,
                        MobileNumberExists = true
                    };
                    return Ok(message);
                }
                message = new SignUpMessageModel()
                {
                    EmailExists = true,
                    MobileNumberExists = false
                };
                return Ok(message);
            }
            else
            {
                Account account = new Account()
                {
                    AccountId = Guid.NewGuid().ToString(),
                    Name = registerUser.Name,
                    Email = registerUser.Email,
                    Password = SHA256Encrypt.ComputePasswordToSha256Hash(registerUser.Password),
                    PhoneNumber = registerUser.PhoneNumber,
                    Status = 0,

                };
                UserDetails userDetails = new UserDetails()
                {
                    UserDetailsId = Guid.NewGuid().ToString(),
                    Age = registerUser.Age,
                    Location = registerUser.Location,
                    GovernmentId = registerUser.GovernmentId,
                    Document = Encoding.ASCII.GetBytes(registerUser.Document),
                    AadhaarNumber = registerUser.AadhaarNumber,
                    BloodType = registerUser.BloodType,
                    


            };
                if (registerUser.Role=="ADMIN")
                {
                    userDetails.rolestatus = 0;
                }
                else if(registerUser.Role == "HOSPITAL")
                {
                    userDetails.rolestatus = 2;

                }
                else if (registerUser.Role == "DONOR")
                {
                    userDetails.rolestatus = 3;

                }
                else
                {
                    userDetails.rolestatus = 1;

                }
                Address address = new Address()
                {
                    AddressId = Guid.NewGuid().ToString(),
                    City = registerUser.City,
                    DoorNo = registerUser.DoorNo,
                    Street = registerUser.Street,
                    State = registerUser.State,
                    PostalCode = registerUser.PostalCode,
                    Area = registerUser.Area,
                    
                };
                AccountUserDetailsAddress accountUserDetailsAddress = new AccountUserDetailsAddress()
                {
                    AccountUserDetailsAddressId=Guid.NewGuid().ToString(),
                    Address = address,
                    Account=account,
                    UserDetails=userDetails
                };
               
               
                Role role = _context.Role.Where(x => x.RoleName == registerUser.Role).FirstOrDefault()!;
                AccountRole accountRole = new AccountRole()
                {
                    AccountRoleId = Guid.NewGuid().ToString(),
                    Role = role,
                    Account = account
                };
                _context.Account.Add(account);
                _context.UserDetails.Add(userDetails);
                _context.Address.Add(address);
                _context.AccountUserDetailsAddress.Add(accountUserDetailsAddress);
                _context.AccountRole.Add(accountRole);
                _context.SaveChanges();

                message = new SignUpMessageModel()
                {
                    EmailExists = false,
                    MobileNumberExists = false
                };
                return Ok(message);
            }

        }
    }
}
