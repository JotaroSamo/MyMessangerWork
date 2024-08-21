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
        public string Name { get; set; } = null!;
        public string? PictureChatPath { get; set; } = null!;
        public string Hub { get; set; } = null!;
        public ICollection<MessageEntity> Messages { get; set; } = [];
        public ICollection<UserEntity> Users { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ChatEntity()
        {
                
        }
    }
}
