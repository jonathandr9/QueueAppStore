using QueueAppStore.Domain.Models;

namespace QueueAppStore.Domain.Services
{
    public interface IClientService
    {
        Task<string> Login(User user);
        Task<int> Register(Client client, User user);
    }
}
