using MasGlobal.HandsOn.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.HandsOn.BL.Interface
{
    /// <summary>
    /// Employee Services Interface
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Get All Records
        /// </summary>
        /// <returns></returns>
         List<EmployeeDTO> GetAll();


        /// <summary>
        /// GEl All External from swagger
        /// </summary>
        /// <returns></returns>
        Task<List<EmployeeDTO>> GetAllExternal();

        /// <summary>
        /// Get employee by Id.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        EmployeeDTO GetById(int employeeId);
    }
}
