using Microsoft.EntityFrameworkCore;
using MyMessagerWork.DataAcess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Repositories
{
    public class ChatRepository : IRepository<ChatEntity>
    {
        private readonly MessagerDbContext _messagerDbContext;

        public ChatRepository(MessagerDbContext messagerDbContext)
        {
           _messagerDbContext = messagerDbContext;
        }
        public async Task<Guid> AddAsync(ChatEntity entity)
        {
            await _messagerDbContext.Chats.AddAsync(entity);
            await _messagerDbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IQueryable<ChatEntity>> AsQueryable() => _messagerDbContext.Chats.AsQueryable();

        public async Task<Guid> DeleteById(Guid id)
        {
            await _messagerDbContext.Chats.Where(i=>i.Id==id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<List<ChatEntity>> GetAllListAsync()
        {
           return await _messagerDbContext.Chats.Include(u=>u.Users).Include(m=>m.Messages).ThenInclude(u=>u.User).ToListAsync();
        }

        public async Task<ChatEntity> GetByIdAsync(Guid id)
        {
            return await _messagerDbContext.Chats.Include(u => u.Users).Include(m => m.Messages).ThenInclude(u => u.User).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Guid> UpdateById(ChatEntity entity)
        {
            await _messagerDbContext.Chats.ExecuteUpdateAsync(s=>s
            .SetProperty(b=>b.Id, b=>entity.Id)
            .SetProperty(b => b.Name, b => entity.Name)
            .SetProperty(b => b.PictureChatPath, b => entity.PictureChatPath)
            .SetProperty(b => b.Users, b => entity.Users)
            .SetProperty(b => b.Messages, b => entity.Messages));
            return entity.Id;
        }
    }
}
