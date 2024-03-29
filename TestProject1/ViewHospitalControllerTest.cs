using BloodBankManagementWebapi.Controllers;
using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ViewHospitalControllerTest
    {
        private ViewHospitalController _controller;

        dynamic optionsbuilder;
        AppDbContext applicationdbContext;

        [SetUp]
        public void Setup()
        {
            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=dummydatabase", new MySqlServerVersion(new Version())); ;
            applicationdbContext = new AppDbContext(optionsbuilder.Options);
            _controller = new ViewHospitalController(applicationdbContext);
        }
        [Test]
        public void GetAccountDetails_WhenCalled_ReturnsHospitalAccounts()
        {
            // Arrange
            var expectedRoleName = "HOSPITAL";
            var role = applicationdbContext.Role.FirstOrDefault(r => r.RoleName == expectedRoleName);
            var expectedAccounts = applicationdbContext.AccountRole.Include(ar => ar.Account).Include(ar => ar.Role).Where(ar => ar.Role == role).ToList();

            // Act
            var result = _controller.GetAccountDetails() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            var hospitalAccounts = result.Value as List<AccountRole>;
            Assert.AreEqual(expectedAccounts.Count, hospitalAccounts.Count);
            Assert.IsTrue(hospitalAccounts.All(ha => ha.Role.RoleName == expectedRoleName));
        }
    }
}
