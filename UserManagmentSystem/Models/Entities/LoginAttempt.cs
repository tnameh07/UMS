using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserManagmentSystem.Models.Entities
{
    public class LoginAttempt
    {
        [Key]
        public int AttemptId { get; set; }

        public int? EmployeeId { get; set; }

        public DateTime AttemptTime { get; set; }

        public bool Success { get; set; }

        [Required]
        [MaxLength(45)]
        public string IPAddress { get; set; }

        // Navigation property
        [ForeignKey("EmployeeId")]
        public Employee employee { get; set; }
    }
}
