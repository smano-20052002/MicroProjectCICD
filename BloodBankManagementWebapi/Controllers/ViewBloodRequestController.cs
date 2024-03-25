using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewBloodRequestController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ViewBloodRequestController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var BloodRequest = _context.BloodRequest.ToList();
            return Ok(BloodRequest);
        }
    }
}
