using MyMessagerWork.Core.Model;
using MyMessagerWork.DataAcess.Entity;
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
        private readonly IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository )
        {
            _repository = repository;
        }
        public async Task<Guid> AddUser(User entity)
        {
            
        }
    }
}
