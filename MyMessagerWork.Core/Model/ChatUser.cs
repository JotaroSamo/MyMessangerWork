using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Core.Model
{
    public class ChatUser
    {
        public Guid ChatId { get; }
        public Chat Chat { get; }
        public Guid UserId { get; }
        public User User { get; }
        public DateTime JoinedAt { get; }

        public ChatUser(Guid chatId, Chat chat, Guid userId, User user, DateTime joinedAt)
        {
            ChatId = chatId;
            Chat = chat;
            UserId = userId;
            User = user;
            JoinedAt = joinedAt;
        }
    }
}
