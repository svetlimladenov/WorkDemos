using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Consumer;

namespace Infrastructure
{
    public class BusFactory
    {
        private const string ConnectionStringKey = "rabbitmq_svetli_connection_string";

        public static IBus CreateBus(bool registerRetryExchange = false)
        {
            //how it should be done
            string connectionString = ConfigurationManager.AppSettings[ConnectionStringKey];

            var myConnectionString = "";
            return CreateBus(myConnectionString);
        }
        public static IBus CreateBus(string connectionString)
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
