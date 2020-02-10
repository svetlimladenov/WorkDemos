
using Autofac;
using Autofac.Core;
using EasyNetQ;
using Infrastructure;

namespace MS.Settings
{
    public static class ContainerFactory
    {
        public static ILifetimeScope CreateLifetimeScope()
        {
            var builder = new ContainerBuilder();

            //what it does behind is that it uses RabbitHutch.CreateBus() and takes the rabbit_mq connection string;
            IBus bus = BusFactory.CreateBus();


            //here inside startup module are registered other services/components with extension methods like RegisterDatabaseContext and RegisterAutoMapper
            //also here the SettingsActionsBO are registered
            //and the settings facade as InstancePerLifetimeScope


            ////builder.RegisterModule(new StartUpModule());

            //In some cases, you may want to pre-generate an instance of an object and add it to the container for use by registered components
            builder.RegisterInstance(bus).As<IBus>();

            //register the setting ms itself, it is in different project 
            ////builder.RegisterType<SettingsMicroservice>().As<IMicroservice>();

            var container = builder.Build();

            return container;
        }
    }
}
