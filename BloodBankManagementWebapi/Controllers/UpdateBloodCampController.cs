using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.Model;
using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateBloodCampController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UpdateBloodCampController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPut]
        public IActionResult UpdateBloodCamp([FromBody] UpdateBloodCamp updateBloodCamp)
        {
            if (!_context.BloodCamp.Any(s=>s.BloodCampId==updateBloodCamp.BloodCampId))
            {
                return BadRequest();

            }
            var OldBloodCamp=_context.BloodCamp.Find(updateBloodCamp.BloodCampId);
            BloodCamp bloodCamp = new BloodCamp()
            {
                BloodCampId = updateBloodCamp.BloodCampId,
                BloodCampName=updateBloodCamp.BloodCampName,
                BloodCampLocation=updateBloodCamp.BloodCampLocation,
                Date=updateBloodCamp.Date,
                Time=updateBloodCamp.Time
            };
            _context.BloodCamp.Entry(OldBloodCamp).State = EntityState.Detached;
            _context.BloodCamp.Update(bloodCamp);
            _context.SaveChanges();
            return Ok();

        }
    }
}
