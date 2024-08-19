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
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public MessageType MessageType { get; set; }
        public string? Text { get; set; }
        public User User { get; set; }
        public Chat Chat { get; set; }
    }
}
