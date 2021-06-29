using ServiceStack;

namespace WebApi.ServiceModel
{
    [Route("/servicestack/employees", Verbs = "GET, POST, PUT")]
    [Route("/servicestack/employees/{Id}", Verbs = "DELETE, GET")]
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    

}