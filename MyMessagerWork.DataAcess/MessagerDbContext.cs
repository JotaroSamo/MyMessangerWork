using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMessagerWork.DataAcess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess
{
   public class MessagerDbContext : DbContext
    {
        public MessagerDbContext(DbContextOptions<MessagerDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<AttachmentEntity> Attachments { get; set; }
        public DbSet<ChatEntity> Chats { get; set; }
    }
}
