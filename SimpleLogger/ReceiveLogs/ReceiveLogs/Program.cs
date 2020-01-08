using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ReceiveLogs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //declare the exchange 
                    channel.ExchangeDeclare(exchange:"logs", type: ExchangeType.Fanout);

                    //auto generater queue name
                    var queueName = channel.QueueDeclare().QueueName;

                    //This can be simply read as: the queue is interested in messages from this exchange.
                    channel.QueueBind(queue: queueName,
                        exchange: "logs",
                        routingKey: "");

                    Console.WriteLine(" [*] Waiting for logs.");
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] {0}", message);
                    };

                    //auto Acknowledgement
                    channel.BasicConsume(
                        queue: queueName,
                        autoAck: true,
                        consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
    }
}
