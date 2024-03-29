using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.Controllers;
using BloodBankManagementWebapi.DataContext;
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
    internal class BloodCampControllerTest
    {



        private BloodCampController _controller;

        dynamic optionsbuilder;
        AppDbContext applicationdbContext;

        [SetUp]
        public void Setup()
        {
            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=dummydatabase", new MySqlServerVersion(new Version())); ;
            applicationdbContext = new AppDbContext(optionsbuilder.Options);
            _controller = new BloodCampController(applicationdbContext);
        }



        //[Test]
        //    public void AddBloodCamp_WhenCalledWithValidData_AddsBloodCampAndReturnsOk()
        //    {
        //        // Arrange
        //        var bloodCampModel = new BloodCampModel
        //        {
        //            BloodCampName = "Test Camp",
        //            BloodCampLocation = "Test Location",
        //            Date = "29-05-2024",
        //            Time = "09:00 AM",
        //            AccountId = "63f3080e-2b43-4d54-96f0-5871f2455fe3" // Replace with an actual account ID from your database
        //        };



        //        // Act
        //        var result = _controller.AddBloodCamp(bloodCampModel) as OkResult;



        //        // Assert
        //        Assert.IsNotNull(result);
        //        Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);



        //        // Additional assertions to verify the blood camp was added to the database
        //        var bloodCampInDb = applicationdbContext.BloodCamp.FirstOrDefault(bc => bc.BloodCampName == bloodCampModel.BloodCampName);
        //        Assert.IsNotNull(bloodCampInDb);
        //        Assert.AreEqual(bloodCampModel.BloodCampLocation, bloodCampInDb.BloodCampLocation);
        //    }



           

    }
}
