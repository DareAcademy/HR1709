using AutoMapper;
using HR1709.data;
using System.ComponentModel.DataAnnotations;

namespace HR1709.Models
{
    [AutoMap(typeof(Nationality), ReverseMap = true)]
    public class NationalityDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
