using Microsoft.AspNetCore.Identity;

namespace Shop.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
    }
}
