using CSharpFunctionalExtensions;
using MyMessagerWork.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Core.Abstract
{
    public interface IUserService
    {
        Task<Guid> AddAsyncUser(User entity);
        Task<Guid> DeleteByIdUser(Guid id);
        Task<List<User>> GetAllListUserAsync();
        Task<User> GetByIdUserAsync(Guid id);
        Task<Guid> UpdateUser(User entity);
        Task<User> GetByEmailUser(string email);
        Task<Result<User>> Register(string name, string email, string password);
        Task<Result<string>> Login(string email, string password);
        //Task<IQueryable<User>> AsQueryable();
        Task SaveAsyncUser();
    }
}
