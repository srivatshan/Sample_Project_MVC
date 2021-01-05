using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Sample_Project.Data.Repository.Interface;
using Sample_Project.Data.Repository.Repo;
using Sample_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Sample_Project
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
          //  builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerRequest();
            builder.RegisterType<LoginService>()
                .As<ILoginService>()
                .InstancePerRequest();

            builder.RegisterType<ApplicationDBContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
           
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);



        }
    }
}