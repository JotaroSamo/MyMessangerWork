using MyMessagerWork.Core.Abstract;
using MyMessagerWork.Core.Model;
using MyMessagerWork.DataAcess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Application.Service
{
    public class UserService: IUserService
    {
        private readonly IRepositoryUser _repository;

        public UserService(IRepositoryUser repository )
        {
            _repository = repository;
        }

        public async Task<Guid> AddAsyncUser(User entity)
        {
           return await _repository.AddAsync(entity);
          
        }


        public async Task<Guid> DeleteByIdUser(Guid id)
        {
          return  await _repository.DeleteById(id);
            
        }

        public async Task<List<User>> GetAllListUserAsync()
        {
           return await _repository.GetAllListAsync();
        }

        public async Task<User> GetByEmailUser(string email)
        {
           return await _repository.GetByEmail(email);
        }

        public async Task<User> GetByIdUserAsync(Guid id)
        {
          return await _repository.GetByIdAsync(id);
        }

        public async Task SaveAsyncUser()
        {
           await _repository.SaveAsync();
        }

        public async Task<Guid> UpdateUser(User entity)
        {
           return await _repository.Update(entity);
        }
    }
}
