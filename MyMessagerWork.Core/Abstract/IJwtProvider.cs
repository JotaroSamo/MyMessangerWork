using MyMessagerWork.Core.Model;

namespace MyMessagerWork.Infrastructure
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}