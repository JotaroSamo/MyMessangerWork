using Microsoft.EntityFrameworkCore;
using MyMessagerWork.DataAcess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Repositories
{
    public class MessageRepository : IRepository<MessageEntity>
    {
        private readonly MessagerDbContext _messagerDbContext;

        public MessageRepository(MessagerDbContext messagerDbContext)
        {
            _messagerDbContext = messagerDbContext;
        }
        public async Task<Guid> AddAsync(MessageEntity entity)
        {
            await _messagerDbContext.Messages.AddAsync(entity);
            return entity.Id;
        }

        public Task<IQueryable<MessageEntity>> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> DeleteById(Guid id)
        {
            await _messagerDbContext.Messages.Where(i => i.Id == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<List<MessageEntity>> GetAllListAsync()
        {
         return  await _messagerDbContext.Messages.ToListAsync();
        }

        public async Task<MessageEntity> GetByIdAsync(Guid id)
        {
            return await _messagerDbContext.Messages.FindAsync(id);
        }

        public async Task<Guid> UpdateById(MessageEntity entity)
        {
            await _messagerDbContext.Messages.Where(i => i.Id == entity.Id).ExecuteUpdateAsync(s => s
            .SetProperty(b=>b.Id, b=>entity.Id)
            .SetProperty(b=>b.DateCreated, b=>entity.DateCreated)
            .SetProperty(b=>b.MessageType, b=>entity.MessageType)
            .SetProperty(b=>b.Text, b=>entity.Text));
            return entity.Id;
        }
    }
}
