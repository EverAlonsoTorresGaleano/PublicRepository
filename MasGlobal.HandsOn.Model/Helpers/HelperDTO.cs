using MasGlobal.HandsOn.Model.DTO;
using MasGlobal.HandsOn.Model.Entities;
using MasGlobal.HandsOn.Model.Enums;
using System;

namespace MasGlobal.HandsOn.Model.Helpers
{

    /// <summary>
    /// Tranform Data Object on DTO Object
    /// </summary>
    public static class HelperDTO
    {
        /// <summary>
        /// Employee to EmployeeDTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EmployeeDTO CreateEmployeeDTO(Employee entity)
        {
            EmployeeDTO returnEntity = null;
            if (entity != null)
            {
                var contractType = (CalculateSalaryTypeEnum)Enum.Parse(typeof(CalculateSalaryTypeEnum), entity.ContractTypeFk.ToString(), true);
                returnEntity = new EmployeeDTO()
                {
                    DocumentNumber = entity.DocumentNumber,
                    EmployeeId = entity.EmployeeId,
                    DocumentTypeFk = entity.DocumentTypeFk,
                    PaymentValue = entity.PaymentValue,
                    LastName = entity.LastName,
                    Name = entity.Name,
                    ContractTypeName = contractType.ToString(),
                    DocumentTypeName = entity.DocumentType.DocumentTypeName,
                    AnnualSalary = contractType == CalculateSalaryTypeEnum.Hourly ? (120 * entity.PaymentValue * 12) : (entity.PaymentValue * 12)
                };
            }
            return returnEntity;
        }
    }
}
