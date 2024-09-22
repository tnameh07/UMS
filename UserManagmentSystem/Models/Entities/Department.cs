using System.ComponentModel.DataAnnotations;

namespace UserManagmentSystem.Models.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
      
       
        public int? CreatedByAdminId { get; set; }

        
        public int? LastModifiedByAdminId { get; set; }
        public DateTime UpdatedAt { get; set; }
       
        public ICollection<Employee> Employees { get; set; }

        
    }
}
