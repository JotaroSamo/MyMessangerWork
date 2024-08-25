using Microsoft.AspNetCore.Authorization;
using MyMessagerWork.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Infrastructure
{
    public class PermissionRequirement(Permission[] permissions)
    : IAuthorizationRequirement
    {
        public Permission[] Permissions { get; set; } = permissions;
    }
}
