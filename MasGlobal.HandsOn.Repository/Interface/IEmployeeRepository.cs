using MasGlobal.HandsOn.Model.Entities;
using System.Collections.Generic;

namespace MasGlobal.HandsOn.Repository.Interface
{

    /// <summary>
    /// Handles Employee Repository
    /// </summary>
    public interface  IEmployeeRepository
    {

        /// <summary>
        /// Get All Records.
        /// </summary>
        /// <returns></returns>
        List<Employee> GetAll();

        /// <summary>
        /// Get Employee by Id.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Employee GetById(int employeeId);
    }
}
