using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class EmployeeRepository: EmployeeInterface
    {
        EmpEntities db = new EmpEntities();
        [HttpGet]
        public IQueryable<Employee> GetEmpsAtDL()
        {
            return db.Employees;
        }

        [HttpGet]
        public IQueryable<Department> GetDeptsAtDL()
        {
            return db.Departments;
        }

        [HttpGet]
        public Employee GetEmpByIdAtDL(int id)
        {
            return db.Employees.Find(id);
        }

        [HttpGet]
        public Employee GetEmpByNameAtDL(string name)
        {
            var y = db.Employees.Where(x => x.EmployeeName == name).FirstOrDefault();
            return y;
        }

        [HttpPost]
        public void PostEmpAtDL(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
        }

        [HttpPut]
        public void PutEmpAtDL(Employee emp)
        {
            var objEmp = new Employee();
            objEmp = db.Employees.Find(emp.EmployeeID);
            if (objEmp != null)
            {
                objEmp.EmployeeName = emp.EmployeeName;
                objEmp.Department = emp.Department;
                objEmp.MailID = emp.MailID;
                objEmp.DOJ = emp.DOJ;
                objEmp.Address = emp.Address;
                objEmp.Phone = emp.Phone;
                objEmp.Salary = emp.Salary;
                objEmp.Age = emp.Age;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteEmpAtDL(Employee emp)
        {
            var y = (from x in db.Employees
                     where x.EmployeeName == emp.EmployeeName
                     select x).First();
            db.Employees.Remove(y);
            db.SaveChanges();
        }
    }
}
