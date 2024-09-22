using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserManagmentSystem.Models.Entities
{
    public class EmployeeDocument
    {
        [Key]
        public int DocumentId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DocumentType { get; set; }

        [Required]
        public string DocumentPath { get; set; }

        public DateTime UploadedAt { get; set; }

        // Navigation property
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
