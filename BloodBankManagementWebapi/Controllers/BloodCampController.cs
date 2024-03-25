using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodCampController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public BloodCampController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddBloodCamp([FromBody]BloodCampModel bloodCampModel)
        {
            BloodCamp bloodCamp = new BloodCamp()
            {
                BloodCampId= Guid.NewGuid().ToString(),
                BloodCampName= bloodCampModel.BloodCampName,
                BloodCampLocation= bloodCampModel.BloodCampLocation,
                Date= bloodCampModel.Date,
                Time = bloodCampModel.Time
            };
            Account account = _context.Account.Find(bloodCampModel.AccountId);
            BloodCampBloodBank bloodCampBloodBank = new BloodCampBloodBank()
            {
                BloodCampBloodBankId = Guid.NewGuid().ToString(),
                BloodCamp = bloodCamp,
                Account = account
            };
            _context.BloodCamp.Add(bloodCamp);
            _context.BloodCampBloodBank.Add(bloodCampBloodBank);
            _context.SaveChanges();
            return Ok();


        }
    }
}
