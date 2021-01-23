using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks; 
using EmployeeManagement.Data;
using EmployeeManagement.ViewModels.ViewModels;

namespace EmployeeManagement.Business
{
    public class EmpBL: IEmpBL
    {
        private EmployeeInterface _employee = new EmployeeRepository();

        public EmpBL() { }

        public EmpBL(EmployeeInterface employee)
        {
            _employee = employee; 
        }

        [HttpGet]
        public IQueryable<EmployeeViewModel> GetEmpsAtBL()
        {
            var employees = _employee.GetEmpsAtDL();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = employees;

            var dest = mapper.Map<IQueryable<Employee>, IList<EmployeeViewModel>>(source);
            return dest.AsQueryable();
        }

        [HttpGet]
        public IQueryable<DepartmentViewModel> GetDeptsAtBL()
        {
            var departments = _employee.GetDeptsAtDL();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = departments;

            var dest = mapper.Map<IQueryable<Department>, IList<DepartmentViewModel>>(source);
            return dest.AsQueryable();
        }

        [HttpGet]
        public EmployeeViewModel GetEmpByIdAtBL(int id)
        {
            var emp = _employee.GetEmpByIdAtDL(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = emp;

            var dest = mapper.Map<Employee, EmployeeViewModel>(source);
            return dest;
        }

        [HttpGet]
        public EmployeeViewModel GetEmpByNameBL(string name)
        {
            var emp = _employee.GetEmpByNameAtDL(name);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = emp;

            var dest = mapper.Map<Employee, EmployeeViewModel>(source);
            return dest;
        }

        [HttpPost]
        public void PostEmpAtBL(EmployeeViewModel emp)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeViewModel, Employee>();
            });

            IMapper mapper = config.CreateMapper();
            var source = emp;
            var dest = mapper.Map<EmployeeViewModel, Employee>(source);
            _employee.PostEmpAtDL(dest);
        }

        [HttpPut]
        public void PutEmpAtBL(EmployeeViewModel emp)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = emp;
            var dest = mapper.Map<EmployeeViewModel, Employee>(source);
            _employee.PutEmpAtDL(dest);
        }

        [HttpDelete]
        public void DeleteEmpAtBL(EmployeeViewModel emp)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeViewModel, Employee>();
            });

            IMapper mapper = config.CreateMapper();
            var source = emp;
            var dest = mapper.Map<EmployeeViewModel, Employee>(source);
            _employee.DeleteEmpAtDL(dest);
        }
    }
}