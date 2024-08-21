using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Entity
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PictureUserPath { get; set; } = null!;
        public string HashPassword { get; set; } = null!;
        public ICollection<ChatEntity> ChatUsers { get; set; } = [];
        public UserEntity()
        {
                
        }
    }

}
