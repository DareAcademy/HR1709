using AutoMapper;
using HR1709.data;

namespace HR1709.Models
{
    [AutoMap(typeof(Position), ReverseMap = true)]
    public class PositionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
