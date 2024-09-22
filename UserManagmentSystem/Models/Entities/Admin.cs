using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserManagmentSystem.Models.Entities
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<Employee> CreatedEmployees { get; set; }
        public ICollection<Employee> ModifiedEmployees { get; set; }
        public ICollection<Department> CreatedDepartments { get; set; }
        public ICollection<Department> ModifiedDepartments { get; set; }
        //[InverseProperty("CreatedByAdmin")]
        //public ICollection<Employee> CreatedEmployees { get; set; }

        //[InverseProperty("ModifiedByAdmin")]
        //public ICollection<Employee> ModifiedEmployees { get; set; }

        //[InverseProperty("CreatedByAdmin")]
        //public ICollection<Department> CreatedDepartments { get; set; }

        //[InverseProperty("ModifiedByAdmin")]
        //public ICollection<Department> ModifiedDepartments { get; set; }
    }
}
