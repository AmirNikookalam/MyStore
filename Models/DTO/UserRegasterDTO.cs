using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DTO
{
    public class UserRegasterDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PassWord { get; set; }

        [Required]
        public string ConfirmPassWord { get; set; }
    }
}
