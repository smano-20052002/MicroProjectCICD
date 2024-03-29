using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ViewBloodStockController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ViewBloodStockController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult ViewBloodStock()
        {
            var BloodStock= _context.BloodStock.Include(y=>y.Account).ToList();
            return Ok(BloodStock);
        }
        [HttpGet]
        public ActionResult ViewBloodStockByIndividual(string id)

        {
            var account = _context.Account.Find(id);
            var BloodStock = _context.BloodStock.Include(y => y.Account).ToList().Where(x=>x.Account==account);
            return Ok(BloodStock);
        }
    }
}
