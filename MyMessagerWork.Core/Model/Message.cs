using MyMessagerWork.DataAcess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Core.Model
{
   public class Message
    {
        public Guid Id { get; }
        public DateTime DateCreated { get;}
        public MessageType MessageType { get;}
        public string? Text { get; }
        public User User { get; }
        public Chat Chat { get; }
    
    }
}
