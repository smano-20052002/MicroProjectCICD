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
    public class RegisterControllerTest
    {

        private RegisterController _controller;

        dynamic optionsbuilder;
        AppDbContext applicationdbContext;
        [SetUp]
        public void Setup()
        {

            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=dummydatabase", new MySqlServerVersion(new Version())); ;
            applicationdbContext = new AppDbContext(optionsbuilder.Options);
            _controller = new RegisterController(applicationdbContext);

        }


        //[Test]
        //public void PostUser_Pass_Returns()
        //{
        //    // Arrange
        //    var registerUser = new RegisterModel
        //    {
        //        Email = "smano8312@gmail.com",
        //        PhoneNumber = 1209560890,
        //        Name = "Mano",
        //        Password = "Relevantz@11991",


        //        Role = "BLOODBANK",
        //        Age = 32,
        //        BloodType = "A+ve",
        //        Location = "Tirunelveli",

        //        GovernmentId = "ajdcsk1234",

        //        Document = "dzsdfghjlk;",

        //        AadhaarNumber = 234567890,
        //        DoorNo = "76",
        //        Street = "Vk street",
        //        Area = "KTC Nagar",
        //        City = "Tirunelveli",
        //        State = "Tamil Nadu",
        //        PostalCode = "45678"
        //    };

        //    var result = _controller.PostUser(registerUser);

        //    // Assert
        //    Assert.IsInstanceOf<OkObjectResult>(result);
        //    var okResult = result as OkObjectResult;
        //    var message = okResult.Value as SignUpMessageModel;
        //    Assert.IsFalse(message.EmailExists);
        //    Assert.IsFalse(message.MobileNumberExists);
        //}

        //[Test]
        //        public void PostUser_With_ExistsEmailAndPhoneNumber_ReturnsFailMessage()
        //        {
        //            // Arrange
        //            var registerUser = new RegisterModel
        //            {
        //                Email = "test@example.com",
        //                PhoneNumber = 1234567890,
        //                Name = "Mano",
        //                Password = "Relevantz@11991",


        //                Role = "ADMIN",
        //                Age = 32,
        //                BloodType = "A=ve",
        //                Location = "Tirunelveli",

        //                GovernmentId = "ajdcsk1234",

        //                Document = "dzsdfghjlk;",

        //                AadhaarNumber = 234567890,
        //                DoorNo = "76",
        //                Street = "Vk street",
        //                Area = "KTC Nagar",
        //                City = "Tirunelveli",
        //                State = "Tamil Nadu",
        //                PostalCode = "45678"
        //            };

        //            var result = _controller.PostUser(registerUser);

        //            // Assert
        //            Assert.IsInstanceOf<OkObjectResult>(result);
        //            var okResult = result as OkObjectResult;
        //            var message = okResult.Value as SignUpMessageModel;
        //            Assert.IsTrue(message.EmailExists);
        //            Assert.IsTrue(message.MobileNumberExists);
        //        }
        //        [Test]
        //        public void PostUser_With_ExistsEmail_ReturnsFailMessage()
        //        {
        //            // Arrange
        //            var registerUser = new RegisterModel
        //            {
        //                Email = "test@example.com",
        //                PhoneNumber = 1230567890,
        //                Name = "Mano",
        //                Password = "Relevantz@11991",


        //                Role = "ADMIN",
        //                Age = 32,
        //                BloodType = "A=ve",
        //                Location = "Tirunelveli",

        //                GovernmentId = "ajdcsk1234",

        //                Document = "dzsdfghjlk;",

        //                AadhaarNumber = 234567890,
        //                DoorNo = "76",
        //                Street = "Vk street",
        //                Area = "KTC Nagar",
        //                City = "Tirunelveli",
        //                State = "Tamil Nadu",
        //                PostalCode = "45678"
        //            };

        //            var result = _controller.PostUser(registerUser);

        //            // Assert
        //            Assert.IsInstanceOf<OkObjectResult>(result);
        //            var okResult = result as OkObjectResult;
        //            var message = okResult.Value as SignUpMessageModel;
        //            Assert.IsTrue(message.EmailExists);
        //            Assert.IsTrue(!message.MobileNumberExists);
        //        }
        //        [Test]
        //        public void PostUser_With_ExistsPhoneNumber_ReturnsFailMessage()
        //        {
        //            // Arrange
        //            var registerUser = new RegisterModel
        //            {
        //                Email = "test@examlple.com",
        //                PhoneNumber = 1234567890,
        //                Name = "Mano",
        //                Password = "Relevantz@11991",


        //                Role = "ADMIN",
        //                Age = 32,
        //                BloodType = "A=ve",
        //                Location = "Tirunelveli",

        //                GovernmentId = "ajdcsk1234",

        //                Document = "dzsdfghjlk;",

        //                AadhaarNumber = 234567890,
        //                DoorNo = "76",
        //                Street = "Vk street",
        //                Area = "KTC Nagar",
        //                City = "Tirunelveli",
        //                State = "Tamil Nadu",
        //                PostalCode = "45678"
        //            };

        //            var result = _controller.PostUser(registerUser);

        //            // Assert
        //            Assert.IsInstanceOf<OkObjectResult>(result);
        //            var okResult = result as OkObjectResult;
        //            var message = okResult.Value as SignUpMessageModel;
        //            Assert.IsTrue(!message.EmailExists);
        //            Assert.IsTrue(message.MobileNumberExists);
        //        }







    }
}
