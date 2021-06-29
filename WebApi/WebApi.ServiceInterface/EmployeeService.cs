using DAL;
using ServiceStack;
using ServiceStack.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.ServiceModel;
using Employees = WebApi.ServiceModel.Employees;

namespace WebApi.ServiceInterface
{

    public class EmployeeService : Service
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

     
        public object Get(Employees employees)
        {
            if ( employees.Id > 0)
            {
                return this.employeeRepository.GetEmployeeById(employees.Id);
            }
            return this.employeeRepository.GetAllEmployees();
        }

        public IHttpResult Post(Employees employees)
        {
            
           var emp =  this.employeeRepository.AddEmployee(new DAL.Employee
            {
                Location = employees.Location,
                Name = employees.Name
            });
            if(emp != null)
                return new HttpResult(System.Net.HttpStatusCode.OK, "Employee Added Successfully.");
            else
                return new HttpResult(System.Net.HttpStatusCode.InternalServerError,
                    " internal server error.");

        }

        public IHttpResult Put(Employees employees)
        {
            var emp = this.employeeRepository.GetEmployeeById(employees.Id);

            if (emp != null)
            {
                this.employeeRepository.UpdateEmployee(new DAL.Employee
                {
                    Id = employees.Id,
                    Location = employees.Location,
                    Name = employees.Name
                });

                return new HttpResult(System.Net.HttpStatusCode.OK, "Employee Updated Successfully.");
            }
            else
            {
                return new HttpResult(System.Net.HttpStatusCode.NotFound, "Employee Not Found.");
            }
        }

        public IHttpResult Delete(Employees employees)
        {
            var emp = this.employeeRepository.GetEmployeeById(employees.Id);
           
            if (emp != null)
            {
                this.employeeRepository.DeleteEmployee(employees.Id);

                return new HttpResult(System.Net.HttpStatusCode.OK, "Removed successfully");
            }
            else
            {
                return new HttpResult(System.Net.HttpStatusCode.NotFound , "Please pass valid Employee Id");
            }
        }
    }
}