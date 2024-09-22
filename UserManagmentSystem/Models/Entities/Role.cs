using System.ComponentModel.DataAnnotations;

namespace UserManagmentSystem.Models.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Role name")]
        [MaxLength(50)]
        public string RoleName { get; set; }

        //e.g., "Project Manager", "Team Lead", "HR Specialist","HR Manager", "Project Lead", "Accountant"
    }
}
