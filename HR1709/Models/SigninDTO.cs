using System.ComponentModel.DataAnnotations;

namespace HR1709.Models
{
    public class SigninDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
