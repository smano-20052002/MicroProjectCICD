using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewBloodRequestByBankController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ViewBloodRequestByBankController(AppDbContext context)
        {
            _context = context;
        }
        [Route("/Get/{id}")]
        [HttpGet]
        public IActionResult Get(string id) {
            var account= _context.Account.Find(id);
            var bank = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(x => x.Account).Where(x => x.Account == account).FirstOrDefault();
            var bloodrequest = _context.BloodRequest.Where(x => x.Location == bank.UserDetails.Location).Where(x => x.Status == 1).ToList();
            return Ok(bloodrequest);
        }

    }
}
