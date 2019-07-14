using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasGlobal.HandsOn.Model.Entities
{
    /// <summary>
    /// Mapping class for Employee Table
    /// </summary>
    [Table("dbo.Employees")]
    public class Employee
    {
        public Employee()
        {

            DocumentType = new DocumentType();
        }

        [Key]
        public int EmployeeId { get; set; }
        public int DocumentTypeFk { get; set; }
        public decimal DocumentNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal PaymentValue { get; set; }
        public int ContractTypeFk { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}
