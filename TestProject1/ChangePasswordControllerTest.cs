using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.Controllers;
using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.Model;
using BloodBankManagementWebapi.OtherOperation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ChangePasswordControllerTest
    {
        private ChangePasswordController _controller;

        dynamic optionsbuilder;
        AppDbContext applicationdbContext;
        [SetUp]
        public void Setup()
        {

            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=dummydatabase", new MySqlServerVersion(new Version())); ;
            applicationdbContext = new AppDbContext(optionsbuilder.Options);
            _controller = new ChangePasswordController(applicationdbContext);

        }
        //[Test]
        //public void ChangePassword_WhenCalledWithValidCredentials_UpdatesPasswordAndReturnsSuccessMessage()
        //{
          
        //    var changePasswordDto = new ChangePassword
        //    {
        //        Email = "smano4570@gmail.com",
        //        OldPassword = "Relevantz@11991",
        //        NewPassword = "Relevantz@11991"
        //    };

        //    // Act
        //    var result = _controller.ChangePassword(changePasswordDto) as OkObjectResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        //    var changePasswordMessage = result.Value as ChangePasswordMessage;
        //    Assert.IsTrue(changePasswordMessage.EmailExists);
        //    Assert.IsTrue(changePasswordMessage.Passcheck);

        //    // Additional assertions to verify the password was updated in the database
        //    var updatedUser = applicationdbContext.Account.FirstOrDefault(a => a.Email == changePasswordDto.Email);
        //    Assert.IsNotNull(updatedUser);
        //    Assert.AreEqual(SHA256Encrypt.ComputePasswordToSha256Hash(changePasswordDto.NewPassword), updatedUser.Password);
        //}
        //[Test]
        //public void ChangePassword_WhenCalledWithInValidEmail_ReturnsFailureMessage()
        //{
        //    // Arrange
           
        //    var changePasswordDto = new ChangePassword
        //    {
        //        Email = "smano4470@gmail.com",
        //        OldPassword = "Relevantz@11991",
        //        NewPassword = "Relevantz@11991"
        //    };

        //    // Act
        //    var result = _controller.ChangePassword(changePasswordDto) as OkObjectResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        //    var changePasswordMessage = result.Value as ChangePasswordMessage;
        //    Assert.IsFalse(changePasswordMessage.EmailExists);
        //    Assert.IsFalse(changePasswordMessage.Passcheck);

          
        //}
        //[Test]
        //public void ChangePassword_WhenCalledWithInValidOldPassword_ReturnsFailureMessage()
        //{
        //    // Arrange
        //     var changePasswordDto = new ChangePassword
        //    {
        //        Email = "smano4570@gmail.com",
        //        OldPassword = "Relevanz@11991",
        //        NewPassword = "Relevantz@11991"
        //    };

        //    // Act
        //    var result = _controller.ChangePassword(changePasswordDto) as OkObjectResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        //    var changePasswordMessage = result.Value as ChangePasswordMessage;
        //    Assert.IsTrue(changePasswordMessage.EmailExists);
        //    Assert.IsFalse(changePasswordMessage.Passcheck);


        //}
    }
}
