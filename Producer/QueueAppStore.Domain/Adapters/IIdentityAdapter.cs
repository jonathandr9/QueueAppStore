using QueueAppStore.Domain.Models;

namespace QueueAppStore.Domain.Adapters
{
    public interface IIdentityAdapter
    {
        Task<Guid> RegisterUser(User user);
        Task<string> Login(User user);
    }
}
