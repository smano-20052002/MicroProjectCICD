using BloodBankManagementWebapi.Controllers;
using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ViewBloodStockControllerTest
    {
        private ViewBloodStockController _controller;

        dynamic optionsbuilder;
        AppDbContext applicationdbContext;

        [SetUp]
        public void Setup()
        {
            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=dummydatabase", new MySqlServerVersion(new Version())); ;
            applicationdbContext = new AppDbContext(optionsbuilder.Options);
            _controller = new ViewBloodStockController(applicationdbContext);
        }
        [Test]
        public void ViewBloodStock_WhenCalled_ReturnsAllBloodStock()
        {
            // Act
            var result = _controller.ViewBloodStock() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            var bloodStocks = result.Value as List<BloodStock>;
            Assert.AreEqual(applicationdbContext.BloodStock.Count(), bloodStocks.Count);
        }

        [Test]
        public void ViewBloodStockByIndividual_WhenCalledWithValidId_ReturnsBloodStockForThatIndividual()
        {
            // Arrange
            var validAccountId = "63f3080e-2b43-4d54-96f0-5871f2455fe3"; // Replace with an actual account ID from your database

            // Act
            var result = _controller.ViewBloodStockByIndividual(validAccountId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            var bloodStocks = result.Value as IEnumerable<BloodStock>;
            Assert.IsTrue(bloodStocks.All(bs => bs.Account.AccountId == validAccountId));
        }


    }
}
