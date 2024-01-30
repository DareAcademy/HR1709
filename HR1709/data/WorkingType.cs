using System.ComponentModel.DataAnnotations.Schema;

namespace HR1709.data
{
    [Table("WorkingTypes")]
    public class WorkingType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
