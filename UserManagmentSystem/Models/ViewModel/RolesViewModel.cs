using System.ComponentModel.DataAnnotations;

namespace UserManagmentSystem.Models.ViewModel
{
    public class RolesViewModel
    {
        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }

        //e.g., "Project Manager", "Team Lead", "HR Specialist","HR Manager", "Project Lead", "Accountant"
    }
}
