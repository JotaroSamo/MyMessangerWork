using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Entity
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PermissionEntity> Permissions { get; set; } = [];
        ICollection<UserEntity> Users { get; set; } = [];
    }
}
