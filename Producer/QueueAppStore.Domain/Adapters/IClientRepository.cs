using QueueAppStore.Domain.Models;

namespace QueueAppStore.Domain.Adapters
{
    public interface IClientRepository
    {
        Task<Client> GetClient();
        Task<int> Add(Client client);
        Task<bool> Exists(int idClient);
    }
}
