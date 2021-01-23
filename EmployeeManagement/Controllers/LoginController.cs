using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Business;
using EmployeeManagement.ViewModels.ViewModels;

namespace EmployeeManagement.Controllers
{
    public class LoginController : ApiController
    {
        ILoginBL _login = new LoginBL();

        LoginController() { }

        LoginController(ILoginBL login)
        {
            _login = login;
        }

        [HttpPost]
        [Route("Api/Login/UserLogin")]
        public Response Login(LoginViewModel Lg)
        {
            var IsValidUser = _login.IsLoggerAtBL(Lg);
            if (IsValidUser)
            {
                return new Response
                {
                    Status = "Success",
                    Message = Lg.UserName
                };
            } else {
                return new Response
                {
                    Status = "Invalid",
                    Message = "Invalid User"
                };
            }
        }

        //For new user Registration  
        [Route("Api/Login/UserRegistration")]
        [HttpPost]
        public object CreateUser(Registration reg)
        {
            var master = new EmployeemasterViewModel();
            if (master.UserId == 0)
            {
                return _login.AddUserAtBL(master, reg);
            }
            else
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Invalid Data."
                };
            }
        }
    }
}