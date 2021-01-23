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
    public class DeptBL : IDeptBL
    {
        private DepartmentInterface _department = new DepartmentRepository();

        public DeptBL() { }

        public DeptBL(DepartmentInterface department)
        {
            _department = department;
        }

        [HttpGet]
        public IQueryable<DepartmentViewModel> GetDeptsAtBL()
        {
            var departments = _department.GetDeptsAtDL();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = departments;

            var dest = mapper.Map<IQueryable<Department>, IList<DepartmentViewModel>>(source);
            return dest.AsQueryable();
        }

        [HttpGet]
        public DepartmentViewModel GetDeptByIdAtBL(int id)
        {
            var dept = _department.GetDeptByIdAtDL(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = dept;

            var dest = mapper.Map<Department, DepartmentViewModel>(source);
            return dest;
        }

        [HttpGet]
        public DepartmentViewModel GetDeptByNameBL(string name)
        {
            var dept = _department.GetDeptByName(name);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = dept;

            var dest = mapper.Map<Department, DepartmentViewModel>(source);
            return dest;
        }

        [HttpPost]
        public void PostDeptAtBL(DepartmentViewModel dept)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DepartmentViewModel, Department>();
            });

            IMapper mapper = config.CreateMapper();
            var source = dept;
            var dest = mapper.Map<DepartmentViewModel, Department>(source);
            _department.PostDeptAtDL(dest);
        }

        [HttpPut]
        public void PutDeptAtBL(DepartmentViewModel dept)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = dept;
            var dest = mapper.Map<DepartmentViewModel, Department>(source);
            _department.PutDeptAtDL(dest);
        }

        [HttpDelete]
        public void DeleteDeptAtBL(DepartmentViewModel dept)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DepartmentViewModel, Department>();
            });

            IMapper mapper = config.CreateMapper();
            var source = dept;
            var dest = mapper.Map<DepartmentViewModel, Department>(source);
            _department.DeleteDeptAtDL(dest);
        }
    }
}