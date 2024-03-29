using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.Model;
using BloodBankManagementWebapi.OtherOperation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcceptRequesterByBankController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AcceptRequesterByBankController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AcceptRequester acceptRequester)
        {
            var requester = _context.BloodRequest.Find(acceptRequester.RequesterId);
            requester.AcceptStatus = 1;
            _context.BloodRequest.Update(requester);
            _context.SaveChanges();

            var account = _context.Account.Find(acceptRequester.AccountId);
            var accountuserdetailsaddress = _context.AccountUserDetailsAddress.Include(x => x.Account).Include(x => x.Address).Include(x => x.UserDetails).Where(x => x.Account == account).FirstOrDefault();


            var userdetails =accountuserdetailsaddress.UserDetails;
            var address =accountuserdetailsaddress.Address;
            BloodStockRequester bloodStockRequester = new BloodStockRequester()
            {
                BloodStockRequesterId=Guid.NewGuid().ToString(),
                Account=account,
                UserDetails=userdetails,
                Address=address,
                BloodRequest= requester
            };
            _context.bloodStockRequesters.Add(bloodStockRequester);
            _context.SaveChanges();
            EmailGenerator.SendEmailForAcceptRequest(requester.Email, requester.BloodRequestId, account, address, userdetails);
            return Ok();






        }
    }
}
