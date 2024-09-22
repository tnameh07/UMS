using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;


namespace UserManagmentSystem.Models.Entities
{
    public class Employee 
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public UserType UserType { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public int? RoleId { get; set;  }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CreatedByAdminId { get; set; }
        public int? LastModifiedByAdminId { get; set; }

        [Required]
        [MaxLength(100)]
        public string StreetAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(20)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        // Navigation properties
        public Department Department { get; set; }

       
        public Role Role { get; set; }
        public ICollection<EmployeeDocument> Documents { get; set; }
        public ICollection<AuditLog> AuditLogs { get; set; }
        public ICollection<LoginAttempt> LoginAttempts { get; set; }
       
    }
    public enum UserType
    {
        Admin,
        Employee
    }
}
