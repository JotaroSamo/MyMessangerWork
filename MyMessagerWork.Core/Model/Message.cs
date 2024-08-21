
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Core.Model
{

    public partial class Message
    {
        public Guid Id { get; }
        public DateTime DateCreated { get; }
        public MessageType Type { get; }
        public string? Text { get; }
        public Guid UserId { get; }
        public Guid ChatId { get; }

        public Message(Guid id, DateTime dateCreated, MessageType type, string? text, Guid userId, Guid chatId)
        {
            Id = id;
            DateCreated = dateCreated;
            Type = type;
            Text = text;
            UserId = userId;
            ChatId = chatId;
        }
    }
}
