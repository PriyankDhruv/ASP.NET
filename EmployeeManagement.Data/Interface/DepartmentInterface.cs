using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public interface DepartmentInterface
    {
        [HttpGet]
        IQueryable<Department> GetDeptsAtDL();

        [HttpGet]
        Department GetDeptByIdAtDL(int id);

        [HttpGet]
        Department GetDeptByName(string name);

        [HttpPost]
        void PostDeptAtDL(Department dept);

        [HttpPut]
        void PutDeptAtDL(Department dept);

        [HttpDelete]
        void DeleteDeptAtDL(Department dept);
    }
}