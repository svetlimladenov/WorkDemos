using System;

namespace SerializationEasyNetQ.Messages
{
    public class TextDTO
    {
        public TextDTO(int id, string content, DateTime sentOn)
        {
            this.Id = id;
            this.Content = content;
            this.SentOn = sentOn;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }
    }
}