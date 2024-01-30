using System.ComponentModel.DataAnnotations.Schema;

namespace HR1709.data
{
    [Table("Positions")]
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
