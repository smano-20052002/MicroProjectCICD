using BloodBankManagementWebapi.ApiModel;
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
namespace TestProject1
{
    public class ForgetPasswordControllerTest
    {
        private ForgetPasswordController _controller;

        dynamic optionsbuilder;
        AppDbContext applicationdbContext;
        [SetUp]
        public void Setup()
        {

            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=dummydatabase", new MySqlServerVersion(new Version())); ;
            applicationdbContext = new AppDbContext(optionsbuilder.Options);
            _controller = new ForgetPasswordController(applicationdbContext);

        }
        //[Test]
        //public void SendMailForPassword_WithEmailExists_ReturnsEmailSent()
        //{
        //    // Arrange
        //    var emailClassMail = new EmailClass
        //    {
        //        Email = "smano4570@gmail.com"
        //    };

           
        //    var result = _controller.SendMailForPassword(emailClassMail);

        //    // Assert
        //    Assert.IsInstanceOf<OkObjectResult>(result);
        //    var okResult = result as OkObjectResult;
        //    var message = okResult.Value as ForgetPasswordMessage;
        //    Assert.IsTrue(message.EmailExists);
        //    Assert.IsTrue(message.SendMail);
        //}

        //[Test]
        //public void SendMailForPassword_WithEmailDoesNotExist_ReturnsEmailNotSent()
        //{
        //    // Arrange
        //    var emailClassMail = new EmailClass
        //    {
        //        Email = "nonexistent@example.com"
        //    };

        //    // Act
        //    var result = _controller.SendMailForPassword(emailClassMail);

        //    // Assert
        //    Assert.IsInstanceOf<OkObjectResult>(result);
        //    var okResult = result as OkObjectResult;
        //    var message = okResult.Value as ForgetPasswordMessage;
        //    Assert.IsFalse(message.EmailExists);
        //    Assert.IsFalse(message.SendMail);
        //}
        
    }
}
