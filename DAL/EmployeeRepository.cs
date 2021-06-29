using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee AddEmployee(Employee employees)
        {
            using (var context = new EmployeeContext())
            {

                var emp = context.Employees.Add(new Employee()
                {
                    Name = employees.Name,
                    Location = employees.Location
                });
                context.SaveChanges();

                return emp;

            }
        }

        public void DeleteEmployee(int id)
        {
            using (var context = new EmployeeContext())
            {

                var emp = context.Employees.Where(x => x.Id == id).FirstOrDefault();

                if (emp != null)
                {
                    context.Employees.Remove(emp);
                    context.SaveChanges();

                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (var context = new EmployeeContext())
            {

                return context.Employees.ToList();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (var context = new EmployeeContext())
            {
                return context.Employees.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var context = new EmployeeContext())
            {

                var emp = context.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();

                if (emp != null)
                {
                    emp.Name = employee.Name;
                    emp.Location = employee.Location;

                    context.SaveChanges();
                }
            }
        }
    }
}
