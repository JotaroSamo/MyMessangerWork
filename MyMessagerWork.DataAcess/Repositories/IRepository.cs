using MyMessagerWork.DataAcess.Entity;

namespace MyMessagerWork.DataAcess.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<Guid> AddAsync(T entity);
        Task<Guid> DeleteById(Guid id);
        Task<List<T>> GetAllListAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<Guid> UpdateById(T entity);
        Task<IQueryable<T>> AsQueryable();
    }
}