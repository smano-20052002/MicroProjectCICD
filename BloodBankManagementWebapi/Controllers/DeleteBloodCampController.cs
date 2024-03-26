using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteBloodCampController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeleteBloodCampController(AppDbContext context)
        {
            _context = context;
        }
        [Route("/BloodCamp/{id}")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var bloodCampBank = _context.BloodCampBloodBank.Where(s => s.BloodCamp.BloodCampId == id).FirstOrDefault();
            var bloodCamp=_context.BloodCamp.Find(id);
            _context.BloodCampBloodBank.Remove(bloodCampBank);
            _context.BloodCamp.Remove(bloodCamp);
            _context.SaveChanges();
            return Ok();
        }
    }
}
