using System.ComponentModel.DataAnnotations;

namespace UserManagmentSystem.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings =false, ErrorMessage ="Please Provide User Name")]
        public string? UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide password")]
        public string? Password { get; set; }
    }
}
