using ServiceStack;
using ServiceStack.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.ServiceModel;

namespace WebApi.ServiceInterface
{

    public class EmployeeService : Service
    {
        private static List<Employees> _employees = new List<Employees>
        {
            new Employees
                {
                    Id =1,
                    Location = "Karnataka",
                    Name = "Sandeep"
                },
        new Employees
                {
                    Id =2,
                    Location = "Delhi",
                    Name = "Sanjay"
                }
        };

        public object Get(Employees employees)
        {
            if ( employees.Id > 0)
            {
                return _employees.Where(x => x.Id == employees.Id).First();
            }
            return _employees;
        }

        public IHttpResult Post(Employees employees)
        {
            Random rd = new Random();

            if(_employees.Any(x => x.Id == employees.Id)){

                return new HttpResult(System.Net.HttpStatusCode.BadRequest, "Given Employee ID exists, please pass unique Empl ID");
            }

            _employees.Add(new Employees
            {
                Id = employees.Id,
                Location = employees.Location,
                Name = employees.Name
            });

            return new HttpResult(System.Net.HttpStatusCode.OK, "Employee Added Successfully.");

        }

        public IHttpResult Put(Employees employees)
        {
            Random rd = new Random();

            if (_employees.Any(x => x.Id == employees.Id))
            {
                _employees.Remove(_employees.Where(x => x.Id == employees.Id).First());

                _employees.Add(new Employees
                {
                    Id = employees.Id,
                    Location = employees.Location,
                    Name = employees.Name
                });
            }
            else
            {
                return new HttpResult(System.Net.HttpStatusCode.BadRequest, "Given Employee ID exists, please pass unique Empl ID");

            }


            return new HttpResult(System.Net.HttpStatusCode.OK, "Employee Updated Successfully.");

        }

        public IHttpResult Delete(Employees employees)
        {
           
            if (_employees.Any(x => x.Id == employees.Id))
            {
                var removed = _employees.Remove(_employees.Where(x => x.Id == employees.Id).First());

                return new HttpResult(System.Net.HttpStatusCode.OK);

            }
            else
            {
                return new HttpResult(System.Net.HttpStatusCode.NotFound , "Please pass valid Employee Id");
            }

        }
    }
}