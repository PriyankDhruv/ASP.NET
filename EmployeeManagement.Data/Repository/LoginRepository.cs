using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Data
{
    public class LoginRepository: LoginInterface
    {
        EmpEntities db = new EmpEntities();
        [HttpPost]
        public bool IsLoggerAtDL(Login Lg)
        {
            var logger = db.Employeemasters.Any(x => x.UserName == Lg.UserName && x.Password == Lg.Password);
            return logger;
        }

        [HttpPost]
        public object AddUserAtDL(Employeemaster master, Registration reg)
        {
            master.UserName = reg.UserName;
            master.Email = reg.Email;
            master.Password = reg.Password;
            master.ContactNo = reg.ContactNo;
            master.Address = reg.Address;
            master.IsApporved = reg.IsApporved;
            master.Status = reg.Status;

            if (IsEmailAlreadyExistsAtDL(reg.Email))
            {
                return new Response
                {
                    Status = "Failure",
                    Message = "Email already Exists!"
                };
            }
            else
            {
                db.Employeemasters.Add(master);
                db.GetValidationErrors();
                db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "SuccessFully Saved"
                };
            }

        }

        [HttpPost]
        public bool IsEmailAlreadyExistsAtDL(string email)
        {
            var user = db.Employeemasters.Any(y => y.Email == email);
            return user;
        }
    }
}
