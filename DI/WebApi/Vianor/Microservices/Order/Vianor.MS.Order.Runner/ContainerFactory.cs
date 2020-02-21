using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using EasyNetQ;
using Vianor.Infrastructure;

namespace Vianor.MS.Order.Runner
{
    public static class ContainerFactory
    {
        public static ILifetimeScope CreateLifetimeScope()
        {
            var builder = new ContainerBuilder();

            var bus = BusFactory.CreateBus();

            builder.RegisterModule(new StartUpModule());
            builder.RegisterInstance(bus).As<IBus>();
            builder.RegisterType<OrderMicroservice>().As<IMicroservice>();

            return builder.Build();
        }
    }
}
