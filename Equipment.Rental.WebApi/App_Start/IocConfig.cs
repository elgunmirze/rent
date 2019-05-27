using Autofac;
using Autofac.Integration.WebApi;
using Equipment.Rental.Infrastructure.Repository;
using Equipment.Rental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Module = Autofac.Module;

namespace Equipment.Rental.WebApi.App_Start
{
    public static class IocConfig
    {

        public static void Initialize()
        {
            IoC.Initialize(new WebApiIocModule());
        }


        public static void Register(HttpConfiguration config)
        {
            Initialize();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(IoC.Instance);
        }
        public class WebApiIocModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                base.Load(builder);

                var config = GlobalConfiguration.Configuration;

                builder.RegisterType<InventoryRepository>().As<IInventoryRepository>().InstancePerLifetimeScope();
                builder.RegisterType<InventoryService>().As<IInventoryService>().InstancePerLifetimeScope();

                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
                builder.RegisterWebApiFilterProvider(config);
            }
        }
    }
}