using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Entity
{
    public class ChatEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? PictureChatPath { get; set; }
        public string Hub { get; set; }
        public IEnumerable<UserEntity> Users { get; set; } 
        public IEnumerable<MessageEntity> Messages { get; set; }
    }
}
