using QueueAppStore.Domain.Adapters;
using QueueAppStore.Domain.Models;
using QueueAppStore.Domain.Services;

namespace QueueAppStore.Application
{
    public sealed class AppService : IAppService
    {
        private readonly IAppRepository _appRepository;

        public AppService(IAppRepository appRepository)
        {
            _appRepository = appRepository; 
        }

        public async Task<IEnumerable<App>> GetAppsList()
        {
            return await _appRepository.GetAll();
        }
    }
}
