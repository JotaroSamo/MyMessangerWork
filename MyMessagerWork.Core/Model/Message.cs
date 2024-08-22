
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace MyMessagerWork.Core.Model
{

    public class Message
    {
        private Message(Guid id, User sender, Guid chatId, string? text, List<Attachment> attachments = null)
        {
            Id = id;
            User = sender ?? throw new ArgumentNullException(nameof(sender));
            ChatId = chatId;
            Text = text;
            DateCreated = DateTime.UtcNow;
            Attachments = attachments ?? new List<Attachment>();
        }

        public Guid Id { get; }
        public DateTime DateCreated { get; }
        public string? Text { get; }
        public Guid UserId { get; }
        public User User { get; }
        public Guid ChatId { get; }
        public IReadOnlyCollection<Attachment> Attachments { get; }

        public static Result<Message> Create(Guid id, User sender, Guid chatId, string? text, List<Attachment> attachments = null)
        {
            if (sender == null)
            {
                return Result.Failure<Message>("Sender is required.");
            }

            var message = new Message(id, sender, chatId, text, attachments);
            return Result.Success(message);
        }
    }

}
