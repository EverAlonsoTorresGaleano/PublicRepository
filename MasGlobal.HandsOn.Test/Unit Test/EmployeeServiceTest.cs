using System.Collections.Generic;
using MasGlobal.HandsOn.BL.Implemetation;
using MasGlobal.HandsOn.BL.Interface;
using MasGlobal.HandsOn.Model.Entities;
using MasGlobal.HandsOn.Repository.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MasGlobal.HandsOn.Test.UnitTest
{
    /// <summary>
    /// Test Class for Employ Service
    /// </summary>
    [TestClass]
    public class EmployeeServiceTest
    {
        /// <summary>
        /// Employee Service Instance
        /// </summary>
        public IEmployeeRepository EmployeeRepository
        {
            get; set;
        }

        public IEmployeeService EmployeeService
        {
            get; set;
        }

        /// <summary>
        /// MOck Employee Repository to avoid go to db.
        /// </summary>
        /// <returns></returns>
        public IEmployeeRepository EmployeeRepositoryMock()
        {
            Mock<IEmployeeRepository> employeeReporitoryMock = new Mock<IEmployeeRepository>();
            List<Employee> searchReturn = new List<Employee>();
            searchReturn.Add(new Employee() { });
            searchReturn.Add(new Employee() { });
            employeeReporitoryMock.Setup(s => s.GetAll()).Returns(searchReturn);
            return employeeReporitoryMock.Object;
        }

        /// <summary>
        /// Start up
        /// </summary>
        [TestInitialize]
        public void EmployeeServiceTest_Initialize()
        {
            EmployeeRepository = EmployeeRepositoryMock();
        }

        /// <summary>
        /// Test Method GetAll
        /// </summary>
        [TestMethod]
        public void EmployeeService_GelAll()
        {
            EmployeeService = new EmployeeService()
            {
                EmployeeRepository= EmployeeRepository
            };
           var resultList = EmployeeService.GetAll();
            Assert.IsTrue(resultList.Count == 2);
        }
    }
}
