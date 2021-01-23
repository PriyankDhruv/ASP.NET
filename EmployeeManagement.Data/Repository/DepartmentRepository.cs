using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class DepartmentRepository: DepartmentInterface
    {
        EmpEntities db = new EmpEntities();
        [HttpGet]
        public IQueryable<Department> GetDeptsAtDL()
        {
            return db.Departments;
        }

        [HttpGet]
        public Department GetDeptByIdAtDL(int id)
        {
            return db.Departments.Find(id);
        }

        [HttpGet]
        public Department GetDeptByName(string name)
        {
            var y = db.Departments.Where(x => x.DepartmentName == name).FirstOrDefault();
            return y;
        }

        [HttpPost]
        public void PostDeptAtDL(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
        }

        [HttpPut]
        public void PutDeptAtDL(Department dept)
        {
            var objDept = GetDeptByIdAtDL(Convert.ToInt32(dept.DepartmentID));
            if (objDept != null)
            {
                objDept.DepartmentName = dept.DepartmentName;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteDeptAtDL(Department dept)
        {
            var y = (from x in db.Departments
                     where x.DepartmentName == dept.DepartmentName
                     select x).First();
            db.Departments.Remove(y);
            db.SaveChanges();
        }
    }
}