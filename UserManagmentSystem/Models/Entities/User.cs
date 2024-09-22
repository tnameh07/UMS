using System.ComponentModel.DataAnnotations;

namespace UserManagmentSystem.Models.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public UserType UserType { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
       
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<AuditLog> AuditLogs { get; set; }
        public ICollection<LoginAttempt> LoginAttempts { get; set; }
    }
    public enum UserType
    {
        Admin,
        Employee
    }
}
