using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloodBankManagementWebapi.Model;
using BloodBankManagementWebapi.ApiModel;
using Microsoft.EntityFrameworkCore;


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
            Random rand = new Random();
            if (bloodRequestDto == null)
            {
                return BadRequest();
            }
           
            BloodRequest bloodRequest= new BloodRequest()
            {
                BloodRequestId = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("/", "-").Replace("+", "-").Substring(rand.Next(0, 10), 8),
                Name=bloodRequestDto.Name,
                Email=bloodRequestDto.Email,
                PhoneNumber=bloodRequestDto.PhoneNumber,
                BloodType=bloodRequestDto.BloodType,
                Age=bloodRequestDto.Age,
                Location=bloodRequestDto.Location,
                Units=bloodRequestDto.Units,
                AcceptStatus=0,
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
            var bloodrequest = _context.BloodRequest.Find(Request.Id);
            
            CheckBloodRequestStatusMessage message = null;


            List<BloodBankStock> bloodstock = new List<BloodBankStock>();

            if (Request == null || !_context.BloodRequest.Any(s=>s.BloodRequestId==Request.Id))
            {
                message = new CheckBloodRequestStatusMessage()
                {
                    IdExists = false,
                    Status = null,
                    bloodRequestBloodBank= bloodstock

                };
                return Ok(message);
            }
            BloodRequest bloodRequest=_context.BloodRequest.Find(Request.Id);
            var BloodBank = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).Where(x => x.UserDetails.rolestatus == 1).Where(x => x.Account.Status != 0).Where(x => x.UserDetails.Location == bloodrequest!.Location).Select(l => new BloodRequestBloodBank
            {
                Id = l.Account.AccountId,
                Name = l.Account.Name,
                Location = l.UserDetails.Location


            }).ToList();

            if (bloodRequest.Status == 1)
            {
                foreach (var bank in BloodBank)
                {
                    var o = _context.BloodStock.Include(c => c.Account).Where(c => c.BloodType == bloodrequest.BloodType).Where(d => d.Account.AccountId == bank.Id).ToList().Select(p => new BloodBankStock
                    {
                        BloodBank = p.Account.Name,
                        Location = bank.Location,
                        Units = p.Units
                    }).FirstOrDefault();
                    bloodstock.Add(o);

                };
                message = new CheckBloodRequestStatusMessage()
                {
                    IdExists = true,
                    Status="approved",
                    bloodRequestBloodBank= bloodstock

                };
                return Ok(message);
            }
            else if(bloodRequest.Status == 2) 
            {

                message = new CheckBloodRequestStatusMessage()
                {
                    IdExists = true,
                    Status = "rejected",
                    bloodRequestBloodBank = bloodstock

                };
                return Ok(message);
            }
            else
            {
                message = new CheckBloodRequestStatusMessage()
                {
                    IdExists = true,
                    Status = "pending",
                    bloodRequestBloodBank = bloodstock
                };
                return Ok(message);
            }



        }
    }
}
