using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using WebMatrix.Data;
using HRMnPRM.Plug.Service;
using HRMnPRM.Plug.Data;

namespace HRMnPRM.Plug.Web
{
    public static class BootStrapper
    {
        public static void Run()
        {
            InitializeAndSeedDb();
            SetIocContainer();
        }

        private static void InitializeAndSeedDb()
        {
            try
            {
                DbInitializerHelper.DefaultInitializeAndSeedDb();
                //DbInitializerHelper.InitializeAndSeedDb();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private static void SetIocContainer()
        {
            try
            {
                //Implement Autofac

                var configuration = GlobalConfiguration.Configuration;
                var builder = new ContainerBuilder();

                // Register MVC controllers using assembly scanning.
                builder.RegisterControllers(Assembly.GetExecutingAssembly());

                // Register MVC controller and API controller dependencies per request.
                builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
                builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();

                // Register service
                builder.RegisterAssemblyTypes(typeof(ApplicationService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerDependency();

                var container = builder.Build();

                //for MVC Controller Set the dependency resolver implementation.
                var resolverMvc = new AutofacDependencyResolver(container);
                System.Web.Mvc.DependencyResolver.SetResolver(resolverMvc);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}