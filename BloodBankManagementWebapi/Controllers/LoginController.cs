using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.Model;
using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.OtherOperation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public LoginController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            AuthMessageModel authmessage;
            List<Claim> authClaim;
            if (loginModel != null)
            {
                if (_context.Account.Any(user => user.Email == loginModel.Email))
                {
                    Account user = _context.Account.Where(user => user.Email == loginModel.Email).FirstOrDefault()!;
                    if (user.Status==1)
                    {
                        if (user.Password == SHA256Encrypt.ComputePasswordToSha256Hash(loginModel.Password))
                        {
                            var accountroleid = _context.AccountRole.Where(userrole => userrole.Account == user)
                                .Select(user => user.AccountRoleId)
                                .FirstOrDefault()!;
                            var roleid = _context.AccountRole.Where(ur => ur.AccountRoleId == accountroleid) // Filter by userrole id
                                                          .Select(ur => ur.Role.RoleId) // Select the role id
                                                          .FirstOrDefault();
                            authClaim = new List<Claim>()
                        {
                            new Claim("Id",user.AccountId),
                            new Claim("Role",roleid!)
                        };
                            var token = Jwt.GenerateJWTToken(authClaim, _configuration);
                            authmessage = new AuthMessageModel
                            {
                                AccountApproval = "approve",
                                AccountExists = true,
                                PasswordStatus = true,
                                Token = token
                            };
                            return Ok(authmessage);
                        }
                        authmessage = new AuthMessageModel
                        {
                            AccountApproval = "approve",
                            AccountExists = true,
                            PasswordStatus = false,
                            Token = null
                        };
                        return Ok(authmessage);

                    }
                    else if(user.Status==2)
                    {
                        if (user.Password == SHA256Encrypt.ComputePasswordToSha256Hash(loginModel.Password))
                        {
                            var accountroleid = _context.AccountRole.Where(userrole => userrole.Account == user)
                                .Select(user => user.AccountRoleId)
                                .FirstOrDefault()!;
                            var roleid = _context.AccountRole.Where(ur => ur.AccountRoleId == accountroleid) // Filter by userrole id
                                                          .Select(ur => ur.Role.RoleId) // Select the role id
                                                          .FirstOrDefault();
                            authClaim = new List<Claim>()
                        {
                            new Claim("Id",user.AccountId),
                            new Claim("Role",roleid!)
                        };
                            var token = Jwt.GenerateJWTToken(authClaim, _configuration);
                            authmessage = new AuthMessageModel
                            {
                                AccountApproval = "reject",
                                AccountExists = true,
                                PasswordStatus = true,
                                Token = token
                            };
                            return Ok(authmessage);
                        }
                        authmessage = new AuthMessageModel
                        {
                            AccountApproval = "reject",
                            AccountExists = true,
                            PasswordStatus = false,
                            Token = null
                        };
                        return Ok(authmessage);

                    }
                    else
                    {
                        if (user.Password == SHA256Encrypt.ComputePasswordToSha256Hash(loginModel.Password))
                        {
                            var accountroleid = _context.AccountRole.Where(userrole => userrole.Account == user)
                                .Select(user => user.AccountRoleId)
                                .FirstOrDefault()!;
                            var roleid = _context.AccountRole.Where(ur => ur.AccountRoleId == accountroleid) // Filter by userrole id
                                                          .Select(ur => ur.Role.RoleId) // Select the role id
                                                          .FirstOrDefault();
                            authClaim = new List<Claim>()
                        {
                            new Claim("Id",user.AccountId),
                            new Claim("Role",roleid!)
                        };
                            var token = Jwt.GenerateJWTToken(authClaim, _configuration);
                            authmessage = new AuthMessageModel
                            {
                                AccountApproval = "pending",
                                AccountExists = true,
                                PasswordStatus = true,
                                Token = token
                            };
                            return Ok(authmessage);
                        }
                        authmessage = new AuthMessageModel
                        {
                            AccountApproval = "pending",
                            AccountExists = true,
                            PasswordStatus = false,
                            Token = null
                        };
                        return Ok(authmessage);

                    }
                }
                authmessage = new AuthMessageModel
                {
                    AccountApproval = "pending",

                    AccountExists = false,
                    PasswordStatus = false,
                    Token = null
                };
                return Ok(authmessage);
            }
            return BadRequest();

        }
    }
}
