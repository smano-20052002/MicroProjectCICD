using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodBankManagementWebapi.ApiModel;
namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminDashboardController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AdminDashboardController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult GetBasicDetails()
        {
            var Hospital = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).Where(x => x.UserDetails.rolestatus == 2).Where(x => x.Account.Status != 0).Count();
            var Donor = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).ToList().Where(x => x.UserDetails.rolestatus == 3).Where(x => x.Account.Status != 0).Count();
            var Bloodcamp = _context.BloodCampBloodBank.ToList().Count();
            var BloodBank = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).Where(x => x.UserDetails.rolestatus == 1).Where(x => x.Account.Status != 0).Count();
            var BloodRequest = _context.BloodRequest.ToList().Count();
            var PendingBloodRequest = _context.BloodRequest.Where(x=>x.Status==0).ToList().Count();
            var HospitalRequest = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).Where(x => x.UserDetails.rolestatus == 2).Where(x => x.Account.Status == 0).Count();
            var BloodBankPendingRequest = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).Where(x => x.UserDetails.rolestatus == 1).Where(x => x.Account.Status == 0).Count();
            var DonorPendingRequest = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).ToList().Where(x => x.UserDetails.rolestatus == 3).Where(x => x.Account.Status == 0).Count();
            var HospitalPendingRequest = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).Where(x => x.UserDetails.rolestatus == 2).Where(x => x.Account.Status == 0).Count();

            var Result=new Dashboard()
            {
                Hospital=Hospital,
                Donor=Donor,
                BloodBank=BloodBank,
                Bloodcamp=Bloodcamp,
                BloodRequest=BloodRequest,
                HospitalRequest=HospitalRequest,
                BloodBankPendingRequest=BloodBankPendingRequest,
                DonorPendingRequest=DonorPendingRequest,
                HospitalPendingRequest =HospitalPendingRequest,
                PendingBloodRequest= PendingBloodRequest
            };
            return Ok(Result);




        }
        [HttpGet]
        public IActionResult GetBloodStockDetails()
        {
            var Apositive = _context.BloodStock.Where(x=>x.BloodType=="A+ve").Sum(x=>x.Units);
            var Bpositive = _context.BloodStock.Where(x => x.BloodType == "B+ve").Sum(x => x.Units);
            var Opositive = _context.BloodStock.Where(x => x.BloodType == "O+ve").Sum(x => x.Units);
            var ABpositive = _context.BloodStock.Where(x => x.BloodType == "AB+ve").Sum(x => x.Units);
            var Anegative = _context.BloodStock.Where(x => x.BloodType == "A-ve").Sum(x => x.Units);
            var Bnegative = _context.BloodStock.Where(x => x.BloodType == "B-ve").Sum(x => x.Units);
            var Onegative = _context.BloodStock.Where(x => x.BloodType == "O-ve").Sum(x => x.Units);
            var ABnegative = _context.BloodStock.Where(x => x.BloodType == "AB-ve").Sum(x => x.Units);
            BloodDashboard bloodDashboard = new BloodDashboard
            {
                ABnegative = ABnegative,
                Bnegative = Bnegative,
                Anegative = Anegative,
                Onegative = Onegative,
                Opositive = Opositive,  
                ABpositive = ABpositive,
                Apositive = Apositive,
                Bpositive   = Bpositive,
            };

            return Ok(bloodDashboard);

        }
        [HttpGet]
        public IActionResult GetBloodStockDetailsByIndividualBank(string Id)
        {
            var account= _context.Account.Find(Id);
            
             var Apositive = _context.BloodStock.Include(x => x.Account).Where(x => x.Account == account).Where(x => x.BloodType == "A+ve").Sum(x => x.Units);
            var Bpositive = _context.BloodStock.Include(x => x.Account).Where(x => x.Account == account).Where(x => x.BloodType == "B+ve").Sum(x => x.Units);
            var Opositive = _context.BloodStock.Include(x => x.Account).Where(x => x.Account == account).Where(x => x.BloodType == "O+ve").Sum(x => x.Units);
            var ABpositive = _context.BloodStock.Include(x => x.Account).Where(x => x.Account == account).Where(x => x.BloodType == "AB+ve").Sum(x => x.Units);
            var Anegative = _context.BloodStock.Include(x => x.Account).Where(x => x.Account == account).Where(x => x.BloodType == "A-ve").Sum(x => x.Units);
            var ABnegative = _context.BloodStock.Include(x => x.Account).Where(x => x.Account == account).Where(x => x.BloodType == "AB-ve").Sum(x => x.Units);
            var Onegative = _context.BloodStock.Include(x => x.Account).Where(x => x.Account == account).Where(x => x.BloodType == "O-ve").Sum(x => x.Units);
            var Bnegative = _context.BloodStock.Include(x => x.Account).Where(x => x.Account == account).Where(x => x.BloodType == "B-ve").Sum(x => x.Units);
             BloodDashboard bloodDashboard = new BloodDashboard
            {
                ABnegative = ABnegative,
                Bnegative = Bnegative,
                Anegative = Anegative,
                Onegative = Onegative,
                Opositive = Opositive,
                ABpositive = ABpositive,
                Apositive = Apositive,
                Bpositive = Bpositive,
               
            };

            return Ok(bloodDashboard);

        }


    }
}
