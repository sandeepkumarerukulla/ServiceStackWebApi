using System.Data.Entity;

namespace DAL
{
    public class EmployeeContext : DbContext
    {

        public EmployeeContext(): base("EmployeeDB")
        { }

        public DbSet<Employees> Employees { get; set; }

    }
}
