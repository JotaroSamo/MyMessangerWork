﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Entity
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PictureUserPath { get; set; }

        public string HashPassword { get; set; }

        public ICollection<ChatUserEntity> ChatUsers { get; set; } = new List<ChatUserEntity>(); // Связь с чатом через отдельный класс
    }

}
