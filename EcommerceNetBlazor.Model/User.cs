using Microsoft.AspNetCore.Identity;

namespace EcommerceNetBlazor.Model
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
//public string? Email { get; set; }

//public string? Password { get; set; }

//public string? Role { get; set; }
