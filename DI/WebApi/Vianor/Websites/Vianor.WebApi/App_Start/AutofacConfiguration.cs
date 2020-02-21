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
            var builder = new ContainerBuilder();

            builder.RegisterType<BusContainer>().As<IBusContainer>().SingleInstance();
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            ILifetimeScope container =  builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}