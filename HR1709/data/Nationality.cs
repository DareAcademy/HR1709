using System.ComponentModel.DataAnnotations.Schema;

namespace HR1709.data
{
    [Table("Nationalities")]
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Employee> liEmployees { get; set; }
    }
}
