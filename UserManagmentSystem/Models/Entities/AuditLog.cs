using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserManagmentSystem.Models.Entities
{
    public class AuditLog
    {
        [Key]
        public int LogId { get; set; }

        public int? EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Action { get; set; }

        [Required]
        [MaxLength(50)]
        public string TableName { get; set; }

        public int? RecordId { get; set; }

        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public DateTime Timestamp { get; set; }

        // Navigation property
        [ForeignKey("EmployeeId")]
        public Employee employee { get; set; }
    }
}
