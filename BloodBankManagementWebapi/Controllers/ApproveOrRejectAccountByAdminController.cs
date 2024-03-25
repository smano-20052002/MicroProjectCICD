using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.Model;
using BloodBankManagementWebapi.OtherOperation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproveOrRejectAccountByAdminController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ApproveOrRejectAccountByAdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ApproveOrRequestAccount([FromBody] ApproveOrReject approveOrReject)
        {

            ApproveOrRejectReturnMessage message = null;
            if (approveOrReject.Id == null || !_context.Account.Any(s => s.AccountId == approveOrReject.Id))
            {
                message = new ApproveOrRejectReturnMessage()
                {
                    ValidEmail = false,
                    IdExists = false,
                    ChangeStatus = false
                };

                return Ok(message);
            }
            Account oldRequest = _context.Account.Where(s => s.AccountId == approveOrReject.Id).FirstOrDefault()!;
            if (approveOrReject.Status == true)
            {
                oldRequest.Status = 1;
                _context.Account.Update(oldRequest);

                if (EmailGenerator.SendEmailForAccountApproval(oldRequest.Name, oldRequest.Email, "AccountApprove"))
                {
                    if (_context.SaveChanges() > 0)
                    {
                        message = new ApproveOrRejectReturnMessage()
                        {
                            ValidEmail = true,
                            IdExists = true,
                            ChangeStatus = true
                        };
                        return Ok(message);

                    }
                    else
                    {
                        message = new ApproveOrRejectReturnMessage()
                        {
                            ValidEmail = true,
                            IdExists = true,
                            ChangeStatus = false
                        };
                        return Ok(message);

                    }
                }
                else
                {
                    message = new ApproveOrRejectReturnMessage()
                    {
                        ValidEmail = false,
                        IdExists = true,
                        ChangeStatus = false
                    };
                    return Ok(message);

                }




            }
            else
            {
                oldRequest.Status = 2;
                _context.Account.Update(oldRequest);

                if (EmailGenerator.SendEmailForAccountApproval(oldRequest.Name, oldRequest.Email, "AccountReject"))
                {
                    if (_context.SaveChanges() > 0)
                    {
                        message = new ApproveOrRejectReturnMessage()
                        {
                            ValidEmail = true,
                            IdExists = true,
                            ChangeStatus = true
                        };
                        return Ok(message);

                    }
                    else
                    {
                        message = new ApproveOrRejectReturnMessage()
                        {
                            ValidEmail = true,
                            IdExists = true,
                            ChangeStatus = false
                        };
                        return Ok(message);

                    }
                }
                else
                {
                    message = new ApproveOrRejectReturnMessage()
                    {
                        ValidEmail = false,
                        IdExists = true,
                        ChangeStatus = false
                    };
                    return Ok(message);

                }




            }


        }
    }
}
