using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Core.Model
{
    public class Chat
    {
        public const int MAX_LENGHT_NAME = 250;

        private Chat(Guid id, string name, string hub, ICollection<User> users, DateTime createAt, DateTime updateAt, ICollection<Message> messages = default, string? pictureChatPath = default)
        {
            Id = id;
            Name = name;
            Hub = hub;
            CreatedAt = createAt;
            UpdatedAt = updateAt;
            Users = users ?? new List<User>();
            Messages = messages ?? new List<Message>();
            PictureChatPath = pictureChatPath;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string? PictureChatPath { get; }
        public string Hub { get; }
        public ICollection<User> Users { get; }
        public ICollection<Message> Messages { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public static Result<Chat> Create(Guid id, string name, string hub, ICollection<User> users, DateTime createAt, DateTime updateAt, ICollection<Message> messages = default, string? pictureChatPath = default)
        {
            if (string.IsNullOrEmpty(name) || name.Length > MAX_LENGHT_NAME)
            {
                return Result.Failure<Chat>($"Name is null or length > {MAX_LENGHT_NAME} symbols");
            }
            if (string.IsNullOrEmpty(hub))
            {
                return Result.Failure<Chat>($"HUB IS ERROR");
            }
            if (users == null)
            {
                return Result.Failure<Chat>($"USERS IS NULL");
            }

            var chat = new Chat(id, name, hub, users, createAt, updateAt, messages, pictureChatPath);
            return Result.Success(chat);
        }
    }

}
