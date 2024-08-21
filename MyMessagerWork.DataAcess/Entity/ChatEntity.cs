﻿using System;
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
        public ICollection<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
        public ICollection<UserEntity> Participants { get; set; } = new List<UserEntity>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
