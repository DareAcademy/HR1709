using Microsoft.AspNetCore.Identity;

namespace HR1709.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
    }
}
