using AutoMapper;
using HR1709.data;

namespace HR1709.Models
{
    [AutoMap(typeof(WorkingType), ReverseMap = true)]
    public class WorkingTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
