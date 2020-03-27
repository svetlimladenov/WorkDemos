using ChatOne.Messages;
using EasyNetQ;
using System;

namespace ChatOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<BaseTextMessage>("test", HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        public static void HandleTextMessage(BaseTextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}, on {1}", textMessage.TextDTO.Content,  textMessage.TextDTO.SentOn);
            Console.ResetColor();
        }
    }
}
