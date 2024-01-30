using AutoMapper;
using HR1709.data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR1709.Models
{
    [AutoMap(typeof(Employee),ReverseMap =true)]
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Department_Id { get; set; }

        [Required]
        public int Position_Id { get; set; }

        [Required]
        public int Working_Type_Id { get; set; }

        [Required]
        public int Nationality_Id { get; set; }

        public string? NationalId { get; set; }

        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"07(7|8|9)\d{7}")]
        public string Phone { get; set; }

        [Required]
        public string MaritalStatus { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public DateTime HiringDate { get; set; }


        public IFormFile fuProfile { get; set; }

        public string? ImageName { get; set; }

        public PositionDTO position { get; set; }

        public DepartmentDTO department { get; set; }


        public NationalityDTO nationality { get; set; }


        public WorkingTypeDTO workingType { get; set; }
    }
}
