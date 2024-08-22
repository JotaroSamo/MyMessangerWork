using MyMessagerWork.Core.Model;

namespace MyMessagerWork.DataAcess.Repositories
{
    public interface IMessageRepository
    {
        Task<Guid> AddAsync(Message entity);
        Task<Guid> DeleteAsync(Guid id);
        Task<List<Message>> GetByChatId(Guid chatid);
        Task SaveAsync();
    }
}