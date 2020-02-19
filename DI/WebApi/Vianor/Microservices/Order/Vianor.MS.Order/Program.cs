using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using Vianor.MS.Order.Contracts;

namespace Vianor.MS.Order
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Vianor.MS.Order Running...");
                bus.RespondAsync<GetAllOrdersMessage, GetAllOrdersResponseMessage>(request =>
                    Task.Factory.StartNew(() =>
                    {
                        return new GetAllOrdersResponseMessage()
                        {
                            OrderIds = new List<string>()
                            {
                                    "1",
                                    "2",
                                    "3"
                            }
                        };
                    }));
                Console.ReadLine();
            }
        }
    }
}
