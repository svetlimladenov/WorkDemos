using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQDemos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var random = new Random();
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (IConnection connection = factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;

                    channel.ExchangeDeclare("youtube_demo_exchange", ExchangeType.Direct);

                    channel.QueueDeclare("youtube_demo_queue", durable: true, autoDelete: false, exclusive: false, arguments: null);

                    channel.QueueBind("youtube_demo_queue", "youtube_demo_exchange", "youtube_demo_routing_key");

                    while (true)
                    {
                        var message = new MyMessage()
                        {
                            Name = "Name " + random.Next(0, 100),
                            Age = random.Next(0, 100)
                        };
                        var messageBodyString = JsonConvert.SerializeObject(message);
                        byte[] messageBody = Encoding.UTF8.GetBytes(messageBodyString);

                        channel.BasicPublish(exchange: "youtube_demo_exchange", "youtube_demo_routing_key", basicProperties: properties, body: messageBody);

                        Console.WriteLine("Published Message" + messageBodyString);

                        //wait before sending another message
                        Thread.Sleep(1000);
                    }
                }
            }
        }
    }
}
