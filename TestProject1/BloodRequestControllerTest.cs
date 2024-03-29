using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.Model;
using BloodBankManagementWebapi.Controllers;
using BloodBankManagementWebapi.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TestProject1
{
    internal class BloodRequestControllerTest
    {
        private BloodRequestController _controller;

        dynamic optionsbuilder;
        AppDbContext applicationdbContext;
        [SetUp]
        public void Setup()
        {

            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=dummydatabase", new MySqlServerVersion(new Version())); ;
            applicationdbContext = new AppDbContext(optionsbuilder.Options);
            _controller = new BloodRequestController(applicationdbContext);

        }
        //[Test]
        //public void RequestBlood_WithValidData_ReturnsOkResultWithRequestId()
        //{
        //    // Arrange
        //    var bloodRequestDto = new BloodRequestDto
        //    {
        //        BloodRequestId = "",
        //        Name = "Mano",
        //        Email = "dlcn@jds.com",
        //        Units = 21,
        //        PhoneNumber = 3244398089,
        //        BloodType = "A-ve",
        //        Age = 32,
        //        Location = "Chennai",
        //        AadhaarNumber = 32456432354,

        //        ValidTime = "",
        //        Status = 0

        //    };

        //    // Act
        //    var result = _controller.RequestBlood(bloodRequestDto);

        //    // Assert
        //    Assert.IsInstanceOf<OkObjectResult>(result);
        //    var okResult = result as OkObjectResult;
        //    Assert.IsNotNull(okResult.Value);
        //}

        //[Test]
        //public void RequestBlood_WithNullDto_ReturnsBadRequest()
        //{
        //    // Act
        //    var result = _controller.RequestBlood(null);

        //    // Assert
        //    Assert.IsInstanceOf<BadRequestResult>(result);
        //}
    }
}
