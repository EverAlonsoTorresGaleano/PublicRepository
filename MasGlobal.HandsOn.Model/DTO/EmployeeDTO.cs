namespace MasGlobal.HandsOn.Model.DTO
{
    /// <summary>
    /// Data Tranfer Object for Employee
    /// </summary>
    public partial class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public int DocumentTypeFk { get; set; }
        public decimal DocumentNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal PaymentValue { get; set; }
        public string ContractTypeName { get; set; }
        public decimal AnnualSalary { get; set; }
        /* For Complete Fk Text name*/
        public string DocumentTypeName { get; set; }
    }
}
