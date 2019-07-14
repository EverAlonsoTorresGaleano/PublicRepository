using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasGlobal.HandsOn.Model.Entities
{
    /// <summary>
    /// Employee Type Table mapping
    /// </summary>
    [Table("dbo.DocumentTypes")]
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
