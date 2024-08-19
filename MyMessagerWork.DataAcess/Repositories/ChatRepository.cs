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
        public Task<Guid> AddAsync(ChatEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<ChatEntity>> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChatEntity>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ChatEntity> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateById(ChatEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
