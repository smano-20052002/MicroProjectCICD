using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.Model;
namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RoleController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult PostRole([FromBody] Role roles)
        {
            Role roles1 = new Role()
            {
                RoleId = Guid.NewGuid().ToString(),
                RoleName = roles.RoleName.ToUpper()
            };
            _context.Role.Add(roles1);
            _context.SaveChanges();
            return Ok();
        }

    }
}
