using MasGlobal.HandsOn.DAL.DataMapper;
using MasGlobal.HandsOn.Model.Entities;
using MasGlobal.HandsOn.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace MasGlobal.HandsOn.Repository.Implementation
{
    /// <see cref="IEmployeeRepository"/>
    public class EmployeeRepository : IEmployeeRepository
    {

        /// <see cref="IEmployeeRepository.GetAll"/>
        public List<Employee> GetAll()
        {
            var context = DataMapperFactory.GetDataContext();
            var returnList = context.Employees.ToList<Employee>();
            return returnList;
        }

        /// <see cref="IEmployeeRepository.GetById(int)"/>
        public Employee GetById(int employeeId)
        {
            var context = DataMapperFactory.GetDataContext();
            var returnList = context.Employees.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
            return returnList;
        }
    }
}
