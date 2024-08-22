using Microsoft.AspNetCore.Http;

namespace MyMessagerWork.Contracts
{
    public record UserRequest(string name, string email, string password)
    {
        
    }
}
