using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;

namespace TheConsumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    //add the queue again to guarantee that the queue is here, if Sure it will be declared, not necessary to add it here
                    channel.QueueDeclare("youtube_demo_queue", durable: true, autoDelete: false, exclusive: false, arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, eventArgs) =>
                    {
                        byte[] body = eventArgs.Body;
                        Console.WriteLine("Received message :" + Encoding.UTF8.GetString(body));

                        //simulate work  
                        //write to the database 
                        // send emails
                        // microservices 
                        Thread.Sleep(3000);
                    };

                    channel.BasicConsume(queue: "youtube_demo_queue", autoAck: true, consumer: consumer);

                    Console.WriteLine("Waiting for messages....");
                    Console.ReadLine();
                }
            }
        }
    }
}
