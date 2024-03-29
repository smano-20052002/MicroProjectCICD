using BloodBankManagementWebapi.Controllers;
using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ViewBloodCampControllerTest
    {
        private ViewBloodCampController _controller;

        dynamic optionsbuilder;
        AppDbContext applicationdbContext;

        [SetUp]
        public void Setup()
        {
            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=dummydatabase", new MySqlServerVersion(new Version())); ;
            applicationdbContext = new AppDbContext(optionsbuilder.Options);
            _controller = new ViewBloodCampController(applicationdbContext);
        }
       

            [Test]

            public void Get_WhenCalled_ReturnsAllBloodCamps()

            {

                // Act

                var result = _controller.Get() as OkObjectResult;

                // Assert

                Assert.IsNotNull(result);

                Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

                var bloodCamps = result.Value as List<BloodCampBloodBank>;

                Assert.AreEqual(applicationdbContext.BloodCampBloodBank.Count(), bloodCamps.Count);

            }

            [Test]

            public void GetByIndividual_WhenCalledWithValidId_ReturnsBloodCampsForThatIndividual()

            {

                // Arrange

                var validAccountId = "63f3080e-2b43-4d54-96f0-5871f2455fe3"; 

                // Act

                var result = _controller.GetByIndividual(validAccountId) as OkObjectResult;

                // Assert

                Assert.IsNotNull(result);

                Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

                var bloodCamps = result.Value as IEnumerable<BloodCampBloodBank>;

                Assert.IsTrue(bloodCamps.All(bc => bc.Account.AccountId == validAccountId));

            }

           

        }

    
}
