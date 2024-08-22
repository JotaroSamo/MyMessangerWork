using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Core.Model
{
    public class User
    {
        private User(Guid id, string name, string email, string hashPassword, string pictureUserPatch = default, ICollection<Chat> chatusers = default)
        {
            Id = id;
            Name = name;
            Email = email;
            HashPassword = hashPassword;
            ChatUsers = chatusers ?? new List<Chat>();
            PictureUserPath = pictureUserPatch;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string? PictureUserPath { get; }
        public ICollection<Chat> ChatUsers { get; }
        public string HashPassword { get; }

        public static Result<User> Create(Guid id, string name, string email, string hashPassword, string pictureUserPatch = default, ICollection<Chat> chatusers = default)
        {
            if (string.IsNullOrEmpty(name) || name.Length > Chat.MAX_LENGHT_NAME)
            {
                return Result.Failure<User>($"The {nameof(name)} is null or length more than {Chat.MAX_LENGHT_NAME} symbols");
            }
            if (string.IsNullOrEmpty(email) || email.Length > Chat.MAX_LENGHT_NAME)
            {
                return Result.Failure<User>($"The {nameof(email)} is null or length more than {Chat.MAX_LENGHT_NAME} symbols");
            }

            var user = new User(id, name, email, hashPassword, pictureUserPatch, chatusers);
            return Result.Success(user);
        }
    }
}

