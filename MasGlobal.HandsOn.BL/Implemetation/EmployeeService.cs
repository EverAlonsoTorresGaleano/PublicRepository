using MasGlobal.HandsOn.BL.Interface;
using MasGlobal.HandsOn.Model.DTO;
using MasGlobal.HandsOn.Model.Helpers;
using MasGlobal.HandsOn.Repository.Implementation;
using MasGlobal.HandsOn.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace MasGlobal.HandsOn.BL.Implemetation
{
    /// <see cref="Implemetation.EmployeeRepository"></see>
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// Dependency Injection for Repository
        /// </summary>
        [Dependency]
        public IEmployeeRepository EmployeeRepository
        {
            get; set;
        }

        /// <see cref="EmployeeRepository.GetAll"/>
        public List<EmployeeDTO> GetAll()
        {
            var repositoryResult = EmployeeRepository.GetAll();
            var returnValue = (from record in repositoryResult
                               select HelperDTO.CreateEmployeeDTO(record)).ToList<EmployeeDTO>();
            return returnValue;
        }

        /// <see cref="EmployeeRepository.GetById"/>
        public EmployeeDTO GetById(int employeeId)
        {
            var repositoryResult = EmployeeRepository.GetById(employeeId);
            var returnValue = HelperDTO.CreateEmployeeDTO(repositoryResult);
            return returnValue;
        }
    }
}
