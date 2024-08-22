using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMessagerWork.Core.Model;
using MyMessagerWork.DataAcess.Entity;

namespace MyMessagerWork.DataAcess.Repositories
{
    public class UserRepository : IRepositoryUser
    {
        private readonly MessagerDbContext _messagerDbContext;
        private readonly IMapper _mapper;

        public UserRepository(MessagerDbContext messagerDbContext, IMapper mapper)
        {
            _messagerDbContext = messagerDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(User entity)
        {
            var userEntity = _mapper.Map<UserEntity>(entity);
            await _messagerDbContext.Users.AddAsync(userEntity);
            await _messagerDbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<Guid> DeleteById(Guid id)
        {
            await _messagerDbContext.Users.Where(i => i.Id == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<List<User>> GetAllListAsync()
        {
            var userEntities = await _messagerDbContext.Users.Include(c => c.ChatUsers).ThenInclude(m=>m.Messages).ToListAsync();
            return _mapper.Map<List<User>>(userEntities);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var userEntity = await _messagerDbContext.Users.
                Include(c => c.ChatUsers)
                .ThenInclude(m => m.Messages)
                .Include(c => c.ChatUsers)
                .ThenInclude(u=>u.Users).FirstOrDefaultAsync(i=>i.Id==id);
            return userEntity == null ? null : _mapper.Map<User>(userEntity);
        }
        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _messagerDbContext.Users.FirstOrDefaultAsync(i => i.Email == email);
            return userEntity == null ? null : _mapper.Map<User>(userEntity);
        }

        public async Task SaveAsync()
        {
            await _messagerDbContext.SaveChangesAsync();
        }

        public async Task<Guid> Update(User entity)
        {
            var userEntity = _mapper.Map<UserEntity>(entity);
            await _messagerDbContext.Users.ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Id, b => userEntity.Id)
                .SetProperty(b => b.Name, b => userEntity.Name)
                .SetProperty(b => b.Email, b => userEntity.Email)
                .SetProperty(b => b.PictureUserPath, b => userEntity.PictureUserPath)
                .SetProperty(b => b.HashPassword, b => userEntity.HashPassword)
                .SetProperty(b => b.ChatUsers, b => userEntity.ChatUsers)
            );
            return entity.Id;
        }
    }

}
