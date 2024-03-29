using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using BloodBankManagementWebapi.Model;
using Microsoft.IdentityModel.Tokens.Configuration;
using System.Text;
using BloodBankManagementWebapi.ApiModel;


namespace BloodBankManagementWebapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ViewAccountRequestController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ViewAccountRequestController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAccountDetails()
        {
         
            var accountDetails = _context.AccountUserDetailsAddress.Include(x=>x.UserDetails).Include(a=>a.Account).Include(s=>s.Address).ToList();
        
            return Ok(accountDetails);
        }
        [HttpGet]
        public IActionResult GetAccountDetailsById(string id)
        {
            var accountDetails = _context.UserDetails.Select(l => new UserDetailsDto
            {
                Document = Encoding.ASCII.GetString(l.Document),
            });
            
            return Ok(accountDetails);
        }
        [HttpGet]
        public IActionResult GetDonorById(string id)
        {
            var account = _context.Account.Find(id);
            var accountDetails = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).ToList().Where(x => x.UserDetails.rolestatus == 3).Where(x => x.Account.Status != 0).Where(x=>x.Account==account);

            return Ok(accountDetails);
        }
        //Approved Donor
        [HttpGet]
        public IActionResult GetAccountDetailsDonor()
        {

            var accountDetails = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).ToList().Where(x => x.UserDetails.rolestatus == 3).Where(x => x.Account.Status != 0);

            return Ok(accountDetails);
        }
        [HttpGet]
        public IActionResult GetAccountDetailsHospital()
        {

            var accountDetails = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).Where(x => x.UserDetails.rolestatus == 2).Where(x => x.Account.Status != 0).Select(l => new HospitalBloodBankDetails
            {
                Id=l.Account.AccountId,
                Name = l.Account.Name,
                Email = l.Account.Email,
                PhoneNumber = l.Account.PhoneNumber,
                Location = l.UserDetails.Location,
                GovernmentId = l.UserDetails.GovernmentId,

                Document = Encoding.ASCII.GetString(l.UserDetails.Document),
                DoorNo = l.Address.DoorNo,
                Street =l.Address.Street,
                Area =l.Address.Area,
                City =l.Address.City,
                State =l.Address.State,
                PostalCode =l.Address.PostalCode,
                Status=l.Account.Status
            }) ;
           

            return Ok(accountDetails);
        }
        [HttpGet]
        public IActionResult GetAccountDetailsBloodBank()
        {

            var accountDetails = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).Where(x => x.UserDetails.rolestatus == 1).Where(x => x.Account.Status != 0).Select(l => new HospitalBloodBankDetails
            {
                Id=l.Account.AccountId,
                Name = l.Account.Name,
                Email = l.Account.Email,
                PhoneNumber = l.Account.PhoneNumber,
                Location = l.UserDetails.Location,
                GovernmentId = l.UserDetails.GovernmentId,

                Document = Encoding.ASCII.GetString(l.UserDetails.Document),
                DoorNo = l.Address.DoorNo,
                Street = l.Address.Street,
                Area = l.Address.Area,
                City = l.Address.City,
                State = l.Address.State,
                PostalCode = l.Address.PostalCode,
                Status = l.Account.Status
            });
            return Ok(accountDetails);
        }
        [HttpGet]
        public IActionResult GetAccountDetailsPendingBloodBank()
        {

            var accountDetails = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).Where(x => x.UserDetails.rolestatus == 1).Where(x => x.Account.Status == 0).Select(l => new HospitalBloodBankDetails
            {
                Id = l.Account.AccountId,

                Name = l.Account.Name,
                Email = l.Account.Email,
                PhoneNumber = l.Account.PhoneNumber,
                Location = l.UserDetails.Location,
                GovernmentId = l.UserDetails.GovernmentId,

                Document = Encoding.ASCII.GetString(l.UserDetails.Document),
                DoorNo = l.Address.DoorNo,
                Street = l.Address.Street,
                Area = l.Address.Area,
                City = l.Address.City,
                State = l.Address.State,
                PostalCode = l.Address.PostalCode,
                Status = l.Account.Status
            });
            return Ok(accountDetails);
        }
        [HttpGet]
        public IActionResult GetAccountDetailsPendingDonor()
        {

            var accountDetails = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).ToList().Where(x => x.UserDetails.rolestatus == 3).Where(x => x.Account.Status == 0);

            return Ok(accountDetails);
        }
        [HttpGet]
        public IActionResult GetAccountDetailsPendingHospital()
        {

            var accountDetails = _context.AccountUserDetailsAddress.Include(x => x.UserDetails).Include(a => a.Account).Include(s => s.Address).Where(x => x.UserDetails.rolestatus == 2).Where(x => x.Account.Status == 0).Select(l => new HospitalBloodBankDetails
            {
                Id= l.Account.AccountId,
                Name = l.Account.Name,
                Email = l.Account.Email,
                PhoneNumber = l.Account.PhoneNumber,
                Location = l.UserDetails.Location,
                GovernmentId = l.UserDetails.GovernmentId,

                Document = Encoding.ASCII.GetString(l.UserDetails.Document),
                DoorNo = l.Address.DoorNo,
                Street = l.Address.Street,
                Area = l.Address.Area,
                City = l.Address.City,
                State = l.Address.State,
                PostalCode = l.Address.PostalCode,
                Status = l.Account.Status
            });


            return Ok(accountDetails);
        }
    }
    

}
