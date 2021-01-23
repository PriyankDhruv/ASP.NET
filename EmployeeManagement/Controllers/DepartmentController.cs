using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagement.Data;
using EmployeeManagement.Business;
using EmployeeManagement.ViewModels.ViewModels;

namespace EmployeeManagement.Controllers
{
    [RoutePrefix("Api/Department")]
    public class DepartmentController : ApiController
    {
        private IDeptBL _department = new DeptBL();

        public DepartmentController() { }

        public DepartmentController(IDeptBL department)
        {
            _department = department;
        }

        [HttpGet]
        [Route("AllDepartments")]
        public IQueryable<DepartmentViewModel>GetDepartments()
        {
            try
            {
                return _department.GetDeptsAtBL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetDepartmentsById/{DepartmentID}")]
        public IHttpActionResult GetDepartmentById(string DepartmentID)
        {
            var objDept = new DepartmentViewModel();
            int Id = Convert.ToInt32(DepartmentID);
            try
            {
                objDept = _department.GetDeptByIdAtBL(Id);
                if (objDept == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(objDept);
        }

        [HttpPost]
        [Route("InsertDepartments")]
        public IHttpActionResult PostDepartment(DepartmentViewModel dept)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _department.PostDeptAtBL(dept);
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(dept);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("UpdateDepartments")]
        public IHttpActionResult PutDepartment(DepartmentViewModel dept)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _department.PutDeptAtBL(dept);
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(dept);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("DeleteDepartments")]
        public IHttpActionResult DeleteDepartment(int id)
        {
            var dept = _department.GetDeptByIdAtBL(id);
            if (dept == null)
            {
                return NotFound();
            }
            _department.DeleteDeptAtBL(dept);
            return Ok(dept);
        }
    }
}