using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Entity
{
    public class ChatUserEntity
    {
        public Guid ChatId { get; set; }
        public ChatEntity Chat { get; set; }

        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        public DateTime JoinedAt { get; set; }
    }
}
