using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace EmitLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (IConnection connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    ////declare the exchange 
                    channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

                    //auto generater queue name
                    var queueName = channel.QueueDeclare().QueueName;

                    //This can be simply read as: the queue is interested in messages from this exchange.
                    channel.QueueBind(queue: queueName,
                        exchange: "logs",
                        routingKey: "");

                    for (int i = 0; i < 5; i++)
                    {
                        var message = new MyMessage()
                        {
                            Name = "TESTNAME",
                            Address = "Sofiq",
                            ShoeSize = 43
                        };
                        string messageBodyString = JsonConvert.SerializeObject(message);
                        byte[] body = Encoding.UTF8.GetBytes(messageBodyString); 
                        channel.BasicPublish(exchange: "logs",
                            routingKey: "red",
                            basicProperties: null,
                            body: body);

                        Console.WriteLine(" [x] Sent {0}", messageBodyString);
                    }
                }

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
                
            }
        }

        private static string GetMessage(string[] args)
        {
            return args.Length > 0 ? string.Join(" ", args) : "info: Hello world";
        }
    }
}
