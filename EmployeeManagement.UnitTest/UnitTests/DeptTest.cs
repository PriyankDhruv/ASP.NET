using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManagement.Data;
using EmployeeManagement.Business;
using EmployeeManagement.ViewModels.ViewModels;

namespace EmployeeManagement.UnitTest
{
    [TestClass]
    public class DeptTest
    {
        private IDeptBL _department = new DeptBL();

        public DeptTest() { }

        public DeptTest(IDeptBL department)
        {
            _department = department;
        }
        
        [TestMethod]
        public void TestDepts()
        {
            Assert.AreNotEqual(null, _department.GetDeptsAtBL());
        }

        [TestMethod]
        public void TestDeptById()
        {
            var deptName = "Gateway Digital"; 
            var dept = _department.GetDeptByIdAtBL(20019);
            Assert.AreEqual(deptName, dept.DepartmentName);
        }

        [TestMethod]
        public void TestCreateDept()
        {
            var dept = new DepartmentViewModel {
                DepartmentName = "TecBridge"
            };

            _department.PostDeptAtBL(dept);

            var x = _department.GetDeptByNameBL(dept.DepartmentName);
            Assert.AreEqual(dept.DepartmentName, x.DepartmentName);
        }

        [TestMethod]
        public void TestUpdtedDept()
        {
            var dept = _department.GetDeptByIdAtBL(20004);

            dept.DepartmentName = "Yemo";
            _department.PutDeptAtBL(dept);

            dept.DepartmentName = "DILX";
            _department.PutDeptAtBL(dept);

            Assert.AreEqual("DILX", dept.DepartmentName);
        }

        [TestMethod]
        public void TestDeleteDept()
        {
            var deptName = "TecBridge";
            var dept = _department.GetDeptByNameBL(deptName);

            _department.DeleteDeptAtBL(dept);

            var deptX = _department.GetDeptByNameBL(deptName);
            Assert.IsNull(deptX);
        }
    }
}