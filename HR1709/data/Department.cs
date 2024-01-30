using System.ComponentModel.DataAnnotations.Schema;

namespace HR1709.data
{
    [Table("Departments")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
