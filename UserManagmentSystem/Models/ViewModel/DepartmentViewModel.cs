using System.ComponentModel.DataAnnotations;

namespace UserManagmentSystem.Models.ViewModel
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Department name")]
        public string? DepartmentName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Set Department as Active or Inactive")]
        public bool IsActive { get; set; } = true;
    }
}
