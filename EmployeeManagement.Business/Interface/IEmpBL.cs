using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using EmployeeManagement.ViewModels.ViewModels;

namespace EmployeeManagement.Business
{
    public interface IEmpBL
    {
        [HttpGet]
        IQueryable<EmployeeViewModel> GetEmpsAtBL();

        [HttpGet]
        IQueryable<DepartmentViewModel> GetDeptsAtBL();

        [HttpGet]
        EmployeeViewModel GetEmpByIdAtBL(int id);

        [HttpGet]
        EmployeeViewModel GetEmpByNameBL(string name);

        [HttpPost]
        void PostEmpAtBL(EmployeeViewModel emp);

        [HttpPut]
        void PutEmpAtBL(EmployeeViewModel emp);

        [HttpDelete]
        void DeleteEmpAtBL(EmployeeViewModel emp);

    }
}