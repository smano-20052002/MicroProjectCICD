using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
           // var bloodstock = _context.BloodBankBloodStock.Where(x => x.BloodStock.BloodType == bloodStockDto.BloodType).Where(i => i.Account.AccountId == bloodStockDto.AccountId).FirstOrDefault();
           // var blood = _context.BloodStock.Where(x => x.BloodStockId == bloodstock.BloodStock.BloodStockId).FirstOrDefault();
           // if (bloodstock == null)
            //{
                BloodStock bloodStock = new BloodStock()
                {
                    BloodStockId = Guid.NewGuid().ToString(),
                    BloodType = bloodStockDto.BloodType,
                    Units = bloodStockDto.Units
                };
                Account account = _context.Account.Find(bloodStockDto.AccountId)!;
                BloodBankBloodStock bloodBankBloodStock = new BloodBankBloodStock()
                {
                    BloodBankBloodStockId = Guid.NewGuid().ToString(),
                    BloodStock = bloodStock,
                    Account = account
                };
                _context.BloodStock.Add(bloodStock);
                _context.BloodBankBloodStock.Add(bloodBankBloodStock);
                _context.SaveChanges();

           // }
         //   else
           // {
             //   blood.Units += bloodStockDto.Units;
             //   _context.BloodStock.Update(blood);
               // _context.SaveChanges();

            //}
           
            return Ok();
        }
    }
}
