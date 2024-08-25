using MyMessagerWork.Core.Enums;

namespace MyMessagerWork.Application.Service
{
    public interface IPermissionService
    {
        Task<HashSet<Permission>> GetPermissionsAsync(Guid userId);
    }
}