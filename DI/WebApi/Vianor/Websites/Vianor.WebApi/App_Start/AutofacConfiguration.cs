using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using EasyNetQ.LightInject;
using Vianor.Infrastructure;

namespace Vianor.WebApi
{
    public static class AutofacConfiguration
    {
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<BusContainer>().As<IBusContainer>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            ILifetimeScope container =  builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}