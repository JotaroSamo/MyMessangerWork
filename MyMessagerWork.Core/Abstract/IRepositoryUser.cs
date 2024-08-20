using MyMessagerWork.Core.Model;

namespace MyMessagerWork.DataAcess.Repositories
{
    public interface IRepositoryUser
    {
        Task<Guid> AddAsync(User entity);
        Task<Guid> DeleteById(Guid id);
        Task<List<User>> GetAllListAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<Guid> Update(User entity);
        //Task<IQueryable<User>> AsQueryable();
        Task SaveAsync();
    }
}