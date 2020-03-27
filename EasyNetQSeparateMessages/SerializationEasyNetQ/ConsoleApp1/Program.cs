using System;
using EasyNetQ;
using ConsoleApp1.Messages;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new BaseTextMessage()
                    {
                        TextDTO = new TextDTO(1, input, DateTime.Now)
                    }); ;
                }
            };
        }
    }
}
