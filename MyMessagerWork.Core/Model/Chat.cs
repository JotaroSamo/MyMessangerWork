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
        public Guid Id { get;}
        public string Name { get; }
        public string? PictureChatPath { get; }
        public string ChatToken { get;}
        public IEnumerable<User> Users { get;}
        public IEnumerable<Message> Messages { get;}
    }
}
