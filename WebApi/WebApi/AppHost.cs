﻿using DAL;
using Funq;
using ServiceStack;
using WebApi.ServiceInterface;

namespace WebApi
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyAspNet
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("WebApi", new[] {
                typeof(EmployeeService).Assembly,
                typeof(MyServices).Assembly
            }) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            //container.AddDbContext<EmployeeContext>();

            container.Register<IEmployeeRepository>(new EmployeeRepository());
             
        }
    }
} 