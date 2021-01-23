using Unity;
using System;
using Unity.Lifetime;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http.Headers;
using EmployeeManagement.Data;
using EmployeeManagement.Business;
using EmployeeManagement.Business.Helper;

namespace EmployeeManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<DepartmentInterface, DepartmentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<EmployeeInterface, EmployeeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<LoginInterface, LoginRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDeptBL, DeptBL>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmpBL, EmpBL>(new HierarchicalLifetimeManager());
            container.RegisterType<ILoginBL, LoginBL>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add( new MediaTypeHeaderValue("text/html"));

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}