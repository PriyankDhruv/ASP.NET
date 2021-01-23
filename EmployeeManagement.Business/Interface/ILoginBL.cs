using EmployeeManagement.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Business
{
    public interface ILoginBL
    {
        [HttpPost]
        bool IsLoggerAtBL(LoginViewModel Lg);

        [HttpPost]
        object AddUserAtBL(EmployeemasterViewModel master, Registration reg);

        [HttpPost]
        bool IsEmailAlreadyExistsAtBL(string email);
    }
}