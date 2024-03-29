using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewBloodStockasWholeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ViewBloodStockasWholeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStock()
        {
            List<StockAllBank> bloodstock = new List<StockAllBank>();
            var BloodBank = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).Where(x => x.UserDetails.rolestatus == 1).Where(x => x.Account.Status != 0).Select(l => new BloodRequestBloodBank
            {
                Id = l.Account.AccountId,
                Name = l.Account.Name,
                Location = l.UserDetails.Location


            }).ToList();

            foreach (var bank in BloodBank)
            {
                var o = _context.BloodStock.Include(c => c.Account).ToList().Select(p => new StockAllBank
                {
                    BloodBankName=bank.Name,
                    Location=bank.Location,
                    BloodType=p.BloodType,
                    Units=p.Units,
                    Mobile=p.Account.PhoneNumber

                }).ToList();
                foreach(var i in o)
                {
                    bloodstock.Add(i);
                }
            };

            return Ok(bloodstock);
        }
    }
}
