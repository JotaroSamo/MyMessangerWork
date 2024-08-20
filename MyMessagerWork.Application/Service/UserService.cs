using MyMessagerWork.Core.Model;
using MyMessagerWork.DataAcess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Application.Service
{
    public class UserService
    {
        private readonly IRepositoryUser _repository;

        public UserService(IRepositoryUser repository )
        {
            _repository = repository;
        }
        public async Task<Guid> AddUser(User entity)
        {
            await _repository.AddAsync( entity );
            return entity.Id;
        }
    }
}
