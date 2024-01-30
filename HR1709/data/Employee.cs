using System.ComponentModel.DataAnnotations.Schema;

namespace HR1709.data
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }

        [ForeignKey("department")]
        public int Department_Id { get; set; }

        [ForeignKey("position")]
        public int Position_Id { get; set; }

        [ForeignKey("workingType")]
        public int Working_Type_Id { get; set; }

        [ForeignKey("nationality")]
        public int Nationality_Id { get; set; }

        public string? NationalId { get; set; }

        public string? Email { get; set; }

        public string Phone { get; set; }


        public string MaritalStatus { get; set; }

        public DateTime DOB { get; set; }

        public DateTime HiringDate { get; set; }

        public virtual Nationality nationality { get; set; }

        public virtual Department department { get; set; }

        public virtual Position position { get; set; }

        public virtual WorkingType workingType { get; set; }

        public string? ImageName { get; set; }
    }
}
