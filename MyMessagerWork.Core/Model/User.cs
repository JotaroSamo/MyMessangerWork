using MyMessagerWork.DataAcess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Core.Model
{
    public class User
    {
        public Guid Id { get; }

        public string Name { get; }
        public string Email { get; }
        public string? PictureUserPath { get;  }
        public IEnumerable<Chat> Chats { get;  }
        public string HashPassword { get; }
    }
}
