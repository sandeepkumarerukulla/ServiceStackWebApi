using ServiceStack;
using WebApi.ServiceModel;

namespace WebApi.ServiceInterface
{
    public class MyServices: Service
    {
        public object Any(Hello hello)
        {
            return "ServiceStack hello App";
        }
    }
}
