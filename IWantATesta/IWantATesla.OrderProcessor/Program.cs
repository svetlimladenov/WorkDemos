using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Logging;
using IWantATesla.Messages;

namespace IWantATesla.OrderProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //this imitates a microservice
            var messageBus = RabbitHutch.CreateBus("host=localhost");
            LogProvider.SetCurrentLogProvider(ConsoleLogProvider.Instance);

            messageBus.Subscribe<TeslaOrder>("my_subscription_id", msg => Console.WriteLine($"Processing order: Model - {msg.Model}, Color - {msg.Color}, CustomerEmail - {msg.CustomerEmail}"));
        }
    }
}
