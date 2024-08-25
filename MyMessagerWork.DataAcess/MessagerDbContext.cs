using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
using MyMessagerWork.DataAcess.Configurations;
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
        private readonly IOptions<AuthorizationOptions> authOptions;

        public MessagerDbContext(DbContextOptions<MessagerDbContext> options, IOptions<AuthorizationOptions> authOptions) :base(options)
        {
            Database.EnsureCreated();
            this.authOptions = authOptions;
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<AttachmentEntity> Attachments { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<ChatEntity> Chats { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessagerDbContext).Assembly);

            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
        }
    }
}
