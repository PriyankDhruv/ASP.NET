using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using EmployeeManagement.ViewModels.ViewModels;

namespace EmployeeManagement.Business
{
    public interface IDeptBL
    {
        [HttpGet]
        IQueryable<DepartmentViewModel> GetDeptsAtBL();

        [HttpGet]
        DepartmentViewModel GetDeptByIdAtBL(int id);

        [HttpGet]
        DepartmentViewModel GetDeptByNameBL(string name);

        [HttpPost]
        void PostDeptAtBL(DepartmentViewModel dept);

        [HttpPut]
        void PutDeptAtBL(DepartmentViewModel dept);

        [HttpDelete]
        void DeleteDeptAtBL(DepartmentViewModel dept);
    }
}