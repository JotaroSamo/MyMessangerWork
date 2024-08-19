using CSharpFunctionalExtensions;
using MyMessagerWork.DataAcess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Core.Model
{
    public class Chat
    {
        const int MAX_LENGHT_NAME = 250;
        private Chat(Guid id, string name, 
            string hub, 
            IEnumerable<User> users, 
            IEnumerable<Message> messages = default, string? pictureChatPath = default)
        {
            
            Id = id;
            Name = name;
            Hub = hub;
            Users = users;
            Messages = messages;
            PictureChatPath = pictureChatPath;
        }
        public Guid Id { get;}
        public string Name { get; }
        public string? PictureChatPath { get; }
        public string Hub { get;}
        public IEnumerable<User> Users { get;}
        public IEnumerable<Message> Messages { get;}
        public static Result<Chat> Create(Guid id,
            string name,
            string hub,
            IEnumerable<User> users,
            IEnumerable<Message> messages = default, string? pictureChatPath = default)
        {
            if (string.IsNullOrEmpty(name)|| name.Length >250)
            {
                return Result.Failure<Chat>($"Name is null or lenght name > the {MAX_LENGHT_NAME} symbols");
            }
            if (string.IsNullOrEmpty(hub))
            {
                return Result.Failure<Chat>($"HUB IS ERORR");
            }
            if (users is null)
            {
                return Result.Failure<Chat>($"USERS IS NULL");
            }
            var chat = new Chat(id, name, hub, users, messages, pictureChatPath);
            return Result.Success<Chat>(chat);
        }
    }
}
