using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Consumer;

namespace Vianor.Infrastructure
{
    public class BusFactory
    {
        public static IBus CreateBus(bool registerRetryExchange = false)
        {
            string connectionString = ConfigurationManager.AppSettings[RabbitMQConstants.ConnectionStringConfigEntryName];
            return CreateBus(connectionString, registerRetryExchange);
        }

        public static IBus CreateBus(string connectionString, bool registerRetryExchange = false)
        {
            var bus = RabbitHutch.CreateBus(connectionString, config =>
            {
                config.Register<IClusterHostSelectionStrategy<ConnectionFactoryInfo>, OrderedClusterHostSelectionStrategy<ConnectionFactoryInfo>>();
                config.EnableLegacyConventions();
            });

            return bus;
        }
    }
}
