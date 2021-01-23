using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Business;
using EmployeeManagement.ViewModels.ViewModels;

namespace EmployeeManagement.UnitTest
{
    [TestClass]
    public class LoginTest
    {
        private ILoginBL _login = new LoginBL();

        public LoginTest() { }

        public LoginTest(ILoginBL login)
        {
            _login = login;
        }

        [TestMethod]
        public void TestLogger()
        {
            var Lg = new LoginViewModel
            {
                UserName = "Priyank.Dhruv",
                Password = "M@havir@1998"
            };

            var logger = _login.IsLoggerAtBL(Lg);
            Assert.AreEqual(true, logger);
        }

        [TestMethod]
        public void TestEmailAlreadyExists()
        {
            string email = "priyank.dhruv@thegatewaycorp.com";

            var user = _login.IsEmailAlreadyExistsAtBL(email);
            Assert.AreEqual(true, user);
        }
    }
}