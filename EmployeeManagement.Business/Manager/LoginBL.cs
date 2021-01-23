using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels.ViewModels;

namespace EmployeeManagement.Business
{
    public class LoginBL: ILoginBL
    {
        private LoginInterface _login = new LoginRepository();

        public LoginBL() { }

        public LoginBL(LoginInterface login)
        {
            _login = login;
        }

        [HttpPost]
        public bool IsLoggerAtBL(LoginViewModel Lg)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LoginViewModel, Login>();
            });

            IMapper mapper = config.CreateMapper();
            var source = Lg;
            var dest = mapper.Map<LoginViewModel, Login>(source);
            var logger = _login.IsLoggerAtDL(dest);
            return logger;
        }

        [HttpPost]
        public object AddUserAtBL(EmployeemasterViewModel master, Registration reg)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeemasterViewModel, Employeemaster>();
            });

            IMapper mapper = config.CreateMapper();
            var source = master;
            var dest = mapper.Map<EmployeemasterViewModel, Employeemaster>(source);
            var visitor = _login.AddUserAtDL(dest, reg);
            return visitor;
        }

        [HttpPost]
        public bool IsEmailAlreadyExistsAtBL(string email)
        {
            var user = _login.IsEmailAlreadyExistsAtDL(email);
            return user;
        }
    }
}