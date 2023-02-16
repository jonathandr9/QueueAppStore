using QueueAppStore.Domain.Models;

namespace QueueAppStore.Domain.Services
{
    public interface IAppService
    {
        Task<IEnumerable<App>> GetAppsList();
    }
}
