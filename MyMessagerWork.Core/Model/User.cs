using CSharpFunctionalExtensions;
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
            string hashPassword, string pictureUserPatch = default, ICollection<ChatUser> chatusers = default )
        {
            Id = id; 
            Name = name; 
            Email = email;
            HashPassword = hashPassword;
            ChathatUsers = chatusers;
            PictureUserPath = pictureUserPatch;
        }
        public Guid Id { get; }

        public string Name { get; }
        public string Email { get; }
        public string? PictureUserPath { get;  }
        public ICollection<ChatUser>? ChathatUsers { get;  }
        public string HashPassword { get; }

        public static Result<User> Create(Guid id, string name, string email,
            string hashPassword, string pictureUserPatch = default, ICollection<ChatUser> chatusers = default)
        {
            if (string.IsNullOrEmpty(name) || name.Length > Chat.MAX_LENGHT_NAME)
            {
                Result.Failure<User>($"The {nameof(name)} is null or lenght more then 250 symbol");
            }
            if (string.IsNullOrEmpty(email) || email.Length > Chat.MAX_LENGHT_NAME)
            {
                Result.Failure<User>($"The {nameof(email)} is null or lenght more then 250 symbol");

            }
            var user = new User(id, name, email, hashPassword, pictureUserPatch, chatusers);
            return Result.Success<User>(user);

        }
      
    }
}
