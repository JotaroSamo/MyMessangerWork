using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMessagerWork.Core.Model.Message;

namespace MyMessagerWork.DataAcess.Entity
{
    public class MessageEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public MessageType MessageType { get; set; }
        public string? Text { get; set; } = null!;
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public MessageEntity()
        {
                
        }
    }

}
