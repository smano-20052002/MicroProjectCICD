using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.Model;
using Microsoft.EntityFrameworkCore;
namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BloodTransactionController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BloodTransactionController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        [HttpPost]
        public IActionResult AddBloodTransaction([FromBody]BloodTransactionModel bloodTransactionModel)
        {
            if(_context.BloodRequest.Any(x=>x.BloodRequestId==bloodTransactionModel.BloodRequestId)) {
                var account = _context.Account.Find(bloodTransactionModel.AccountId);
                var bloodRequest = _context.BloodRequest.Find(bloodTransactionModel.BloodRequestId);
                bloodRequest.Status = 4;
                _context.BloodRequest.Update(bloodRequest);
                _context.SaveChanges();
                BloodTransaction bloodTransaction = new BloodTransaction()
                {
                    BloodTransactionId = Guid.NewGuid().ToString(),
                    BloodType = bloodTransactionModel.BloodType,
                    units = bloodTransactionModel.units,
                    Date = bloodTransactionModel.Date,
                    Time = bloodTransactionModel.Time,
                    Account = account,
                    BloodRequest = bloodRequest
                };
                var bloodStock = _context.BloodStock.Include(x => x.Account).Where(x => x.Account == account).Where(x => x.BloodType == bloodTransactionModel.BloodType).Select(x => new BloodStock
                {
                    BloodStockId = x.BloodStockId,
                    BloodType = x.BloodType,
                    Units = x.Units

                }).FirstOrDefault();
                bloodStock.Units = bloodStock.Units - bloodTransactionModel.units;
                _context.BloodStock.Update(bloodStock);
                _context.SaveChanges();
                _context.BloodTransaction.Add(bloodTransaction);
                _context.SaveChanges();
                return Ok();
            }
           
                return BadRequest();
           

          
            

        }
        [HttpPost]
        public IActionResult GetBloodTransaction([FromBody]GetBloodTransaction getBloodTransaction)
        {
            var bloodTransaction = _context.BloodTransaction.Include(x => x.Account).Include(x => x.BloodRequest).Where(x => x.Account.AccountId == getBloodTransaction.Id).ToList();
            return Ok(bloodTransaction);
        }
    }
}
