
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Core.Model
{
    public partial class Message
    {
        public Guid Id { get; }
        public DateTime DateCreated { get;}
        public MessageType Type { get;}
        public string? Text { get; }
        public  Guid UserId { get; }
        public Guid ChatId { get; }

    }
}
