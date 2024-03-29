using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BloodBankManagementWebapi.Controllers;
using BloodBankManagementWebapi.ApiModel;
using BloodBankManagementWebapi.DataContext;
using BloodBankManagementWebapi.Model;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    public class RoleControllerTest
    {
        private RoleController _controller;

        dynamic optionsbuilder;
        AppDbContext applicationdbContext;
        [SetUp]
        public void Setup()
        {

            optionsbuilder = new DbContextOptionsBuilder().UseMySql("server=localhost;user=root;password=admin123;database=dummydatabase", new MySqlServerVersion(new Version())); ;
            applicationdbContext = new AppDbContext(optionsbuilder.Options);
            _controller = new RoleController(applicationdbContext);

        }
        //[Test]
        //public void CallPostRoleAndReturnPassCase()
        //{
        //    Role roles1 = new Role()
        //    {
        //        RoleId = Guid.NewGuid().ToString(),
        //        RoleName = "DONOR"
        //    };
        //    var result = _controller.PostRole(roles1);
        //    Assert.IsInstanceOf<OkResult>(result);
        //}
    }

}
