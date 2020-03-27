using EasyNetQ;

namespace ChatOne.Messages
{
    [Queue("BaseTextMessage", ExchangeName = "BaseTextExchange")]
    public class BaseTextMessage
    {
        public TextDTO TextDTO { get; set; }
    }
}
