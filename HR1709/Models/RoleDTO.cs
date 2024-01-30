using System.ComponentModel.DataAnnotations;

namespace HR1709.Models
{
    public class RoleDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
