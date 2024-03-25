using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ViewBloodCampController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ViewBloodCampController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var BloodCamp= _context.BloodCampBloodBank.Include(x => x.BloodCamp).Include(x=>x.Account).ToList();
            return Ok(BloodCamp);

        }
        [HttpGet]
        public IActionResult GetByIndividual(string id)
        {
            var account = _context.Account.Find(id);
            var BloodCamp = _context.BloodCampBloodBank.Include(x => x.BloodCamp).Include(x => x.Account).Where(x=>x.Account==account);
            return Ok(BloodCamp);

        }

    }
}
