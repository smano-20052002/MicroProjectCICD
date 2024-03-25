using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.Model;
using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloodBankManagementWebapi.OtherOperation;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Org.BouncyCastle.Asn1.Ocsp;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproveBloodRequestByAdminController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ApproveBloodRequestByAdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ApproveOrRequestBloodRequest([FromBody] ApproveOrReject approveOrReject)
        {

            ApproveOrRejectReturnMessage message = null;
            if(approveOrReject.Id==null || !_context.BloodRequest.Any(s=>s.BloodRequestId==approveOrReject.Id))
            {
                message = new ApproveOrRejectReturnMessage()
                {
                    ValidEmail= false,
                    IdExists= false,
                    ChangeStatus =false
                };
                
                return Ok(message);
            }
            BloodRequest oldRequest=_context.BloodRequest.Where(s => s.BloodRequestId == approveOrReject.Id).FirstOrDefault()!;
            if(approveOrReject.Status == true)
            {
                oldRequest.Status = 1;
                oldRequest.ValidTime=DateTime.Now.AddDays(2).ToString();
                _context.BloodRequest.Update(oldRequest);
                
                if(EmailGenerator.SendEmail(oldRequest.Name, oldRequest.Email, "BloodRequestApprove", oldRequest.BloodRequestId, oldRequest.ValidTime))
                {
                    if (_context.SaveChanges()>0)
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
                oldRequest.Status = 0;
                _context.BloodRequest.Update(oldRequest);
               
                if (EmailGenerator.SendEmail(oldRequest.Name, oldRequest.Email, "BloodRequestReject", oldRequest.BloodRequestId, oldRequest.ValidTime))
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
