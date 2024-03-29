using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.Controllers;
using BloodBankManagementWebapi.DataContext;
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
    public class BloodStockControllerTest
    {
        private BloodStockController _controller;

        dynamic optionsbuilder;
        AppDbContext applicationdbContext;

        [SetUp]
        public void Setup()
        {
            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=dummydatabase", new MySqlServerVersion(new Version())); ;
            applicationdbContext = new AppDbContext(optionsbuilder.Options);
            _controller = new BloodStockController(applicationdbContext);
        }
        [Test]
        public void AddBloodStock_WhenCalled_AddsBloodStockAndReturnsOk()
        {
            // Arrange
            var bloodStockDto = new BloodStockDto
            {
                BloodType = "A+",
                Units = 5,
                AccountId = "63f3080e-2b43-4d54-96f0-5871f2455fe3" // Replace with an actual account ID from your database
            };

            // Act
            var result = _controller.AddBloodStock(bloodStockDto) as OkResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

            
         
        }
    }
}
