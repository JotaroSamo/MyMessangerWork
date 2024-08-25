using MyMessagerWork.Core.Enums;
using MyMessagerWork.DataAcess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Application.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IUserRepository _usersRepository;

        public PermissionService(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<HashSet<Permission>> GetPermissionsAsync(Guid userId)
        {
            return _usersRepository.GetUserPermissions(userId);
        }
    }
}
