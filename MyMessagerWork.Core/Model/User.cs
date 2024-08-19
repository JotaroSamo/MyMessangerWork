using CSharpFunctionalExtensions;
using MyMessagerWork.DataAcess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Core.Model
{
    public  class User
    {

        private User(Guid id, string name, string email, 
            string hashPassword, string pictureUserPatch = default, ICollection<Chat> chats = default )
        {
            Id = id; 
            Name = name; 
            Email = email;
            HashPassword = hashPassword;
            Chats = chats;
            PictureUserPath = pictureUserPatch;
        }
        public Guid Id { get; }

        public string Name { get; }
        public string Email { get; }
        public string? PictureUserPath { get;  }
        public ICollection<Chat>? Chats { get;  }
        public string HashPassword { get; }

        public static Result<User> Create(Guid id, string name, string email,
            string hashPassword, string pictureUserPatch = default, ICollection<Chat> chats = default)
        {
            if (string.IsNullOrEmpty(name) || name.Length > Chat.MAX_LENGHT_NAME)
            {
                Result.Failure<User>($"The {nameof(name)} is null or lenght more then 250 symbol");
            }
            if (string.IsNullOrEmpty(email) || email.Length > Chat.MAX_LENGHT_NAME)
            {
                Result.Failure<User>($"The {nameof(email)} is null or lenght more then 250 symbol");

            }
            var user = new User(id, name, email, hashPassword, pictureUserPatch, chats);
            return Result.Success<User>(user);

        }
        public static User Mapper(Guid id, string name, string email,
            string hashPassword, string pictureUserPatch = default, ICollection<Chat> chats = default)
        {
            var user = new User(id, name, email, hashPassword, pictureUserPatch, chats);
            return user;
        }
    }
}
