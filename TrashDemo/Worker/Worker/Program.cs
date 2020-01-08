using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Util;
//receiver the message
namespace Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            using (IConnection connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueDeclare(queue: "task_queue_durable",
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);


                    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Received message : {0}", message);

                        int dots = message.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);

                        Console.WriteLine(" [x] Done");

                        //send the Manual message acknowledgments
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                    };

                    channel.BasicConsume(queue: "task_queue",
                                 autoAck: true,
                                 consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
    }
}
