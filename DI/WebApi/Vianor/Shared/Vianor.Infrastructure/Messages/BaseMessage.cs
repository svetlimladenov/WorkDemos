using System;

namespace Vianor.Infrastructure.Messages
{
    public abstract class BaseMessage : IMessage
    {
        public BaseMessage()
        {
            this.Version = "1.0.0";
            this.Sender = string.Empty;
            this.SentOnDate = DateTime.UtcNow;
        }
        public string Version { get; set; }

        public string Sender { get; set; }

        public DateTime SentOnDate { get; set; }
    }
}
