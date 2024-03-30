using Microsoft.EntityFrameworkCore;
using BloodBankManagementWebapi.Model;
namespace BloodBankManagementWebapi.DataContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Account> Account{ get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<AccountRole>  AccountRole { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<BloodCamp> BloodCamp { get; set; }
        public DbSet<BloodStock> BloodStock { get; set; }
        public DbSet<BloodTransaction> BloodTransaction { get; set; }
        public DbSet<BloodRequest> BloodRequest { get; set; }

        public DbSet<BloodStockRequester> bloodStockRequesters { get; set; }    

        public DbSet<AccountUserDetailsAddress> AccountUserDetailsAddress { get; set; }
      

        public DbSet<BloodCampBloodBank> BloodCampBloodBank { get; set; }


    }
}
