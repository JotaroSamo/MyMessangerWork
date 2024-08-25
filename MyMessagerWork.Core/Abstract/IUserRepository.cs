using MyMessagerWork.Core.Enums;
using MyMessagerWork.Core.Model;
using System;

namespace MyMessagerWork.DataAcess.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> AddAsync(User entity);
        Task<Guid> DeleteById(Guid id);
        Task<List<User>> GetAllListAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<Guid> Update(User entity);
        Task<User> GetByEmail(string email);
        //Task<IQueryable<User>> AsQueryable();
        Task<HashSet<Permission>> GetUserPermissions(Guid userId);
        Task SaveAsync();
    }
}