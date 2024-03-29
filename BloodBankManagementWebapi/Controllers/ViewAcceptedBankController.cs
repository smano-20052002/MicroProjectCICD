using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloodBankManagementWebapi.Model;
using Microsoft.EntityFrameworkCore;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewAcceptedBankController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ViewAcceptedBankController(AppDbContext context)
        {
            _context = context;
        }
        [Route("/GetBank/{id}")]
        [HttpGet]
        public IActionResult GetBankbyId(string id)
        {
            if (_context.BloodRequest.Any(x=>x.AcceptStatus==1))
            {
                var requester = _context.BloodRequest.Find(id);
                var bank = _context.bloodStockRequesters.Include(x => x.UserDetails).Include(x => x.Account).Include(x => x.BloodRequest).Include(x => x.Address).Where(x => x.BloodRequest == requester).ToList();
                return Ok(bank);
            }
            else
            {
                return Ok(null);
            }
           
        }
    }
}
