using QueueAppStore.Domain.Models;

namespace QueueAppStore.Domain.Adapters
{
    public interface IAppRepository
    {
        Task<IEnumerable<App>> GetAll();
        Task<App> GetApp(int appId);
    }
}
