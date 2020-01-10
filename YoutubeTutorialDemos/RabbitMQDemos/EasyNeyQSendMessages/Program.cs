using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using Messages;

namespace EasyNeyQSendMessages
{
    public class MyResponse
    {
        public string Message { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //Subscribe();
            //Publish();

            //Receive();
            //Send();


            Response();
            Request();
        }

        private static void Response()
        {
            var bus = RabbitHutch.CreateBus("host=localhost");
            bus.Respond<MyMessage, MyResponse>(x =>
            {
                return new MyResponse()
                {
                    Message = string.Format($"Response {x.Name}, {x.Age}")
                };
            });
        }


        private static void Request()
        {
            var rand = new Random();
            var bus = RabbitHutch.CreateBus("host=localhost");

            while (true)
            {
                var message = new MyMessage()
                {
                    Name = "Test name " + rand.Next(10),
                    Age = rand.Next(0, 100)
                };

                Console.WriteLine("Sending a request");
                //this can be done async too
                //if no process to receive requests, this will timeout
                var response = bus.Request<MyMessage, MyResponse>(message);
                Console.WriteLine(response.Message);
                Thread.Sleep(1000);
            }
        }

        private static void Receive()
        {
            var bus = RabbitHutch.CreateBus("host=localhost");
            bus.Receive("my.queue", x => x.Add<MyMessage>(m =>
                {
                    Console.WriteLine($"Received MyMessage {m.Name} {m.Age}");
                })
                .Add<MyOtherMessage>(m => { Console.WriteLine($"Received MyMessageOther {m.Address} {m.Taxes}"); }));
        }

        private static void Send()
        {
            var rand = new Random();
            var bus = RabbitHutch.CreateBus("host=localhost");

            while (true)
            {
                var message = new MyMessage()
                {
                    Name = "Test name " + rand.Next(10),
                    Age = rand.Next(0, 100)
                };

                var otherMessage = new MyOtherMessage()
                {
                    Address = "Sofia" + rand.Next(1000, 10000),
                    Taxes = Convert.ToDecimal(rand.NextDouble())
                };
                bus.Send("my.queue", message);
                bus.Send("my.queue", otherMessage);
                Console.WriteLine("Send 2 different message");
                Thread.Sleep(1000);
            }
        }

        private static void Subscribe()
        {
            var bus = RabbitHutch.CreateBus("host=localhost");
            bus.Subscribe<MyMessage>("sub_id", x => { Console.WriteLine($"Received the message: {x.Name} {x.Age}"); });
        }

        private static void Publish()
        {
            var rand = new Random();
            var bus = RabbitHutch.CreateBus("host=localhost");

            while (true)
            {
                var message = new MyMessage()
                {
                    Name = "Test name " + rand.Next(10),
                    Age = rand.Next(0, 100)
                };
                bus.Publish(message);
                Console.WriteLine("Published message");
                Thread.Sleep(1000);
            }
        }
    }
}

