using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
