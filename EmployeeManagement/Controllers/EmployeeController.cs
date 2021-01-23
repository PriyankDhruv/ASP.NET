
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
    [RoutePrefix("Api/Employee")]
    public class EmployeeController : ApiController
    {
        private IEmpBL _employee = new EmpBL();

        public EmployeeController() { }

        public EmployeeController(IEmpBL employee)
        {
            _employee = employee;
        }

        [HttpGet]
        [Route("AllEmployees")]
        public IQueryable<EmployeeViewModel>GetEmployees()
        {
            try
            {
                return _employee.GetEmpsAtBL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("Department")]
        public IQueryable<DepartmentViewModel>GetDepartments()
        {
            try
            {
                return _employee.GetDeptsAtBL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetEmployeesById/{employeeId}")]
        public IHttpActionResult GetEmployeeById(string employeeId)
        {
            var objEmp = new EmployeeViewModel();
            int Id = Convert.ToInt32(employeeId);
            try
            {
                objEmp = _employee.GetEmpByIdAtBL(Id);
                if (objEmp == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(objEmp);
        }

        [HttpPost]
        [Route("InsertEmployees")]
        public IHttpActionResult PostEmployee(EmployeeViewModel emp)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _employee.PostEmpAtBL(emp);
                } catch (Exception)
                {
                    throw;
                }
                return Ok(emp);
            } else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("UpdateEmployees")]
        public IHttpActionResult PutEmployee(EmployeeViewModel emp)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _employee.PutEmpAtBL(emp);
                } catch (Exception)
                {
                    throw;
                }
                return Ok(emp);
            } else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("DeleteEmployees")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var emp = _employee.GetEmpByIdAtBL(id);
            if(emp == null)
            {
                return NotFound();
            }
            _employee.DeleteEmpAtBL(emp);
            return Ok(emp);
        }
    }
}