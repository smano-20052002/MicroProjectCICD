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
    public class BloodStockController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BloodStockController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddBloodStock([FromBody] BloodStockDto bloodStockDto)
        {
            var bloodstockcount = _context.BloodStock.Include(z => z.Account).Where(x => x.BloodType == bloodStockDto.BloodType).Where(i => i.Account.AccountId == bloodStockDto.AccountId).Count();
            if (bloodstockcount == 0)
            {
                Account account = _context.Account.Find(bloodStockDto.AccountId)!;
                BloodStock bloodStock = new BloodStock()
                {
                    BloodStockId = Guid.NewGuid().ToString(),
                    BloodType = bloodStockDto.BloodType,
                    Units = bloodStockDto.Units,
                    Account= account
                };
               
                _context.BloodStock.Add(bloodStock);
                _context.SaveChanges();
                return Ok();

            }
            else
            {
                var bloodstock = _context.BloodStock.Include(z => z.Account).Where(x => x.BloodType == bloodStockDto.BloodType).Where(i => i.Account.AccountId == bloodStockDto.AccountId).FirstOrDefault();
                var blood = _context.BloodStock.Where(x => x.BloodStockId == bloodstock.BloodStockId).FirstOrDefault();

                blood.Units += bloodStockDto.Units;
                _context.BloodStock.Update(blood);
                _context.SaveChanges();
                return Ok();

            }




        }
        [Route("GetStockByBank/{id}/{type}")]
        [HttpGet]
        public IActionResult Get(string id,string type)
        {
            var account = _context.Account.Find(id);
            var bloodstock = 0;
            var blood = _context.BloodStock.Include(a => a.Account).Where(e => e.Account == account).Where(d => d.BloodType == type).FirstOrDefault();
            if (blood == null)
            {
                bloodstock = 0;
            }
            else
            {
                bloodstock=blood.Units;
            }
                
            return Ok(bloodstock);
        }
    }
}
