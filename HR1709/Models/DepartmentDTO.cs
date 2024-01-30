using AutoMapper;
using HR1709.data;

namespace HR1709.Models
{
    [AutoMap(typeof(Department),ReverseMap =true)]
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
