using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManagement.Business;
using EmployeeManagement.ViewModels.ViewModels;
using EmployeeManagement.Data;

namespace EmployeeManagement.UnitTest
{
    [TestClass]
    public class EmpTest
    {
        private IEmpBL _employee = new EmpBL();
        
        public EmpTest() { }

        public EmpTest(IEmpBL employee)
        {
            _employee = employee;
        }

        [TestMethod]
        public void TestEmps()
        {
            Assert.AreNotEqual(null, _employee.GetEmpsAtBL());
        }

        [TestMethod]
        public void TestEmpDepts()
        {
            var empBL = new EmpBL();
            Assert.AreNotEqual(null, _employee.GetDeptsAtBL());
        }

        [TestMethod]
        public void TestEmpById()
        {
            var empName = "Abhijeet Trivedi";
            var emp = _employee.GetEmpByIdAtBL(20008);
            Assert.AreEqual(empName, emp.EmployeeName);
        }

        [TestMethod]
        public void TestCreateEmp()
        {
            var emp = new EmployeeViewModel {
                EmployeeName = "Hemant.Mohapatra",
                Department = "Autofacets",
                MailID = "hemant.mohapatra@thegatewaycorp.com",
                DOJ = Convert.ToDateTime("2020-10-10 18:30:00.000"),
                Phone = 8900366424,
                Address = "02, 3-Prahladnagar Society, Dr. Yagnik Rd, Surat-394105",
                Salary = 32000,
                Age = 23
            };

            _employee.PostEmpAtBL(emp);

            var x = _employee.GetEmpByNameBL(emp.EmployeeName);
            Assert.AreEqual(emp.EmployeeName, x.EmployeeName);
        }

        [TestMethod]
        public void TestUpdtedEmp()
        {
            var emp = _employee.GetEmpByIdAtBL(20008);

            emp.Department = "AutoDAP";
            _employee.PutEmpAtBL(emp);

            emp.Department = "Autofacets";
            _employee.PutEmpAtBL(emp);

            Assert.AreEqual("Autofacets", emp.Department);
        }

        [TestMethod]
        public void TestDeleteEmp()
        {
            var empName = "Hemant.Mohapatra";
            var emp = _employee.GetEmpByNameBL(empName);

            _employee.DeleteEmpAtBL(emp);

            var empX = _employee.GetEmpByNameBL(empName);
            Assert.IsNull(empX);
        }
    }
}