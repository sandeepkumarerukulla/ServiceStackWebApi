using ServiceStack;

namespace WebApi.ServiceModel
{
    [Route("/hello", Verbs = "GET")]
    public class Hello
    {
        public string Name { get; set; }
    }

    

}