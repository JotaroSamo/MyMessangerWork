using Microsoft.EntityFrameworkCore;
using MyMessagerWork.Core.Model;
using MyMessagerWork.DataAcess.Entity;

namespace MyMessagerWork.DataAcess.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly MessagerDbContext _messagerDbContext;

        public UserRepository(MessagerDbContext messagerDbContext)
        {
            _messagerDbContext = messagerDbContext;
        }

        public async Task<List<UserEntity>> GetAllListAsync()
        {
            return await _messagerDbContext.Users.Include(c => c.Chats).ToListAsync();
        }
        public async Task<User> GetByIdAsync(Guid id)
        {
            //return await _messagerDbContext.Users.
            //    Include(c=>c.Chats).
            //    FirstOrDefaultAsync(i=>i.Id == id);
        }
        public async Task<Guid> AddAsync(User entity)
        {
            var user = 
            await _messagerDbContext.AddAsync(entity);
            await _messagerDbContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<Guid> UpdateById(User entity)
        {

            await _messagerDbContext.Users.Where(i => i.Id == entity.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => entity.Name)
                .SetProperty(b => b.Email, b => entity.Email)
                .SetProperty(b => b.HashPassword, b => entity.HashPassword)
                .SetProperty(b=>b.PictureUserPath, b=>entity.PictureUserPath)
                .SetProperty(b=>b.Chats, b=>entity.Chats)
                );
            return entity.Id;
        }
        public async Task<Guid> DeleteById(Guid id)
        {

            await _messagerDbContext.Users.Where(i => i.Id == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<IQueryable<User>> AsQueryable()
        {
            var userEntity = _messagerDbContext.Users.AsQueryable();
            var user = userEntity.Select(s =>User.Mapper(s.Id, s.Name, s.Email, s.HashPassword, s.PictureUserPath, s.Chats));
            return user;
        }
    }
}
