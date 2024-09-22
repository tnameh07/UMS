
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagmentSystem.Models.Entities
{
    [Table("user_account")]
    public class UserAccount
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_name")]
        [MaxLength(100)]
        public string? UserName { get; set; }



        [Column("password")]
        [MaxLength(100)]
        public string? password { get; set; }


        [Column("role")]
        [MaxLength(20)]
        public string? Role { get; set; }
    }
}
