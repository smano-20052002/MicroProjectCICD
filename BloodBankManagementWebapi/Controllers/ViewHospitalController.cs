using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewHospitalController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ViewHospitalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAccountDetails()
        {
            var role = _context.Role.Where(s => s.RoleName == "HOSPITAL").FirstOrDefault();
            var hospitalaccount = _context.AccountRole.Include(s=>s.Account).Include(a=>a.Role).Where(e=>e.Role==role).ToList();
            
            return Ok(hospitalaccount);
        }
    }
}
