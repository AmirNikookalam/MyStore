using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DTO
{
    public class UserLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PassWord { get; set; }
    }
}
