using System;

namespace ChatOne.Messages
{
    public class TextDTO
    {
        public TextDTO(int id, string content, DateTime sentOn)
        {
            Id = id;
            Content = content;
            SentOn = sentOn;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }
    }
}