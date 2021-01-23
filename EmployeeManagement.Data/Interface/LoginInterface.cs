using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Data
{
    public interface LoginInterface
    {
        [HttpPost]
        bool IsLoggerAtDL(Login Lg);

        [HttpPost]
        object AddUserAtDL(Employeemaster master, Registration reg);

        [HttpPost]
        bool IsEmailAlreadyExistsAtDL(string email);
    }
}