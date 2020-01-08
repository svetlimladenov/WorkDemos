using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Producer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //We'll focus on the last one -- the fanout. Let's create an exchange of this type, and call it logs:
                    channel.ExchangeDeclare("logs", ExchangeType.Fanout);

                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueDeclare(queue: "task_queue_durable",
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    //That relationship between exchange and a queue is called a binding
                    channel.QueueBind(queue: queueName,
                                      exchange: "logs",
                                      routingKey: "");

                    var message = GetMessage(args);
                    var body = Encoding.UTF8.GetBytes(message);

                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.BasicPublish(exchange: "logs",
                                        routingKey: "",
                                        basicProperties: null,
                                        body: body);

                    Console.WriteLine($"Message send : {message}");
                }
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
