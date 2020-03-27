using EasyNetQ;

namespace ConsoleApp1.Messages
{
    [Queue("BaseTextMessage", ExchangeName = "BaseTextExchange")]
    public class BaseTextMessage
    {
        public TextDTO TextDTO { get; set; }
    }
}
