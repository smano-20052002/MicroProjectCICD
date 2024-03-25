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
    public class UpdateBloodStockController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UpdateBloodStockController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPut]
        public IActionResult UpdateBloodStock([FromBody]UpdateBloodStock updateBloodStock)
        {
            if (!_context.BloodCamp.Any(s => s.BloodCampId == updateBloodStock.BloodStockId))
            {
                return BadRequest();

            }
            var OldBloodStock = _context.BloodStock.Find(updateBloodStock.BloodStockId);
            BloodStock bloodStock = new BloodStock()
            {
                BloodStockId = updateBloodStock.BloodStockId,
                BloodType = updateBloodStock.BloodType,
                Units= updateBloodStock.Units,
               
            };
            _context.BloodStock.Entry(OldBloodStock).State = EntityState.Detached;
            _context.BloodStock.Update(bloodStock);
            _context.SaveChanges();
            return Ok();
        }

    }
}
