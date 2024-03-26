using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloodBankManagementWebapi.Model;
using BloodBankManagementWebapi.ApiModel;
using Microsoft.EntityFrameworkCore;
//using System.ComponentModel;
//using System.Text;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BloodRequestController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BloodRequestController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult RequestBlood([FromBody] BloodRequestDto bloodRequestDto)
        {
            if (bloodRequestDto == null)
            {
                return BadRequest();
            }
           
            BloodRequest bloodRequest= new BloodRequest()
            {
                BloodRequestId = Guid.NewGuid().ToString(),
                Name=bloodRequestDto.Name,
                Email=bloodRequestDto.Email,
                PhoneNumber=bloodRequestDto.PhoneNumber,
                BloodType=bloodRequestDto.BloodType,
                Age=bloodRequestDto.Age,
                Location=bloodRequestDto.Location,
                AadhaarNumber=bloodRequestDto.AadhaarNumber,
                ValidTime=bloodRequestDto.ValidTime,
                Status = bloodRequestDto.Status
                
            };
            _context.BloodRequest.Add(bloodRequest);
            if (_context.SaveChanges()>0)
            {
                return Ok(bloodRequest.BloodRequestId);
            }
            return BadRequest();
                

        }
        [HttpPost]
        public IActionResult CheckStatus([FromBody]CheckRequest Request)
        {
            CheckBloodRequestStatusMessage message = null;
            var BloodBank= _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).Where(x => x.UserDetails.rolestatus == 1).Where(x => x.Account.Status != 0).Select(l => new BloodRequestBloodBank
            {
                Name = l.Account.Name,
                Location = l.UserDetails.Location
               
               
            }).ToList();
            if (Request == null || !_context.BloodRequest.Any(s=>s.BloodRequestId==Request.Id))
            {
                message = new CheckBloodRequestStatusMessage()
                {
                    IdExists = false,
                    Status = null,
                    bloodRequestBloodBank= null

                };
                return Ok(message);
            }
            BloodRequest bloodRequest=_context.BloodRequest.Find(Request.Id);
            if (bloodRequest.Status == 1)
            {
                message = new CheckBloodRequestStatusMessage()
                {
                    IdExists = true,
                    Status="approved",
                    bloodRequestBloodBank=BloodBank
                    
                };
                return Ok(message);
            }
            else if(bloodRequest.Status == 2) 
            {

                message = new CheckBloodRequestStatusMessage()
                {
                    IdExists = true,
                    Status = "rejected",
                    bloodRequestBloodBank = null

                };
                return Ok(message);
            }
            else
            {
                message = new CheckBloodRequestStatusMessage()
                {
                    IdExists = true,
                    Status = "pending",
                    bloodRequestBloodBank=null
                };
                return Ok(message);
            }



        }
    }
}
