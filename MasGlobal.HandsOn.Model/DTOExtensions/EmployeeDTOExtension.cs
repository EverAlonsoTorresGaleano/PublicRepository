namespace MasGlobal.HandsOn.Model.DTO
{
    /// <summary>
    /// Extend DTO
    /// </summary>
    public partial class EmployeeDTO
    {
        public string FullName
        {
            get
            {
                return $"{this.Name} {this.LastName}";
            }

        }

    }
}
