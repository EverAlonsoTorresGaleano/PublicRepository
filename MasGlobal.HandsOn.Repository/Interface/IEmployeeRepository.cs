using MasGlobal.HandsOn.Model.Entities;
using MasGlobal.HandsOn.Model.Integrations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.HandsOn.Repository.Interface
{

    /// <summary>
    /// Handles Employee Repository
    /// </summary>
    public interface IEmployeeRepository
    {

        /// <summary>
        /// Get All Records.
        /// </summary>
        /// <returns></returns>
        List<Employee> GetAll();


        /// <summary>
        /// Gett All Employye from external Api
        /// </summary>
        /// <returns></returns>
        Task<List<EmployeeSwagger>> GetAllExternal();

        /// <summary>
        /// Get Employee by Id.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Employee GetById(int employeeId);
    }
}
