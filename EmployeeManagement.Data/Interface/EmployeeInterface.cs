using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeManagement.Data
{
    public interface EmployeeInterface
    {
        [HttpGet]
        IQueryable<Employee> GetEmpsAtDL();

        [HttpGet]
        IQueryable<Department> GetDeptsAtDL();

        [HttpGet]
        Employee GetEmpByIdAtDL(int id);

        [HttpGet]
        Employee GetEmpByNameAtDL(string name);

        [HttpPost]
        void PostEmpAtDL(Employee emp);

        [HttpPut]
        void PutEmpAtDL(Employee emp);

        [HttpDelete]
        void DeleteEmpAtDL(Employee emp);
    }
}
