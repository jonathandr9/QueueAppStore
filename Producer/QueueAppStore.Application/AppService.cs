using Newtonsoft.Json;
using QueueAppStore.Domain.Adapters;
using QueueAppStore.Domain.Models;
using QueueAppStore.Domain.Services;

namespace QueueAppStore.Application
{
    public sealed class AppService : IAppService
    {
        private readonly IAppRepository _appRepository;
        private readonly ICachingAdapter _cachingAdapter;

        public AppService(IAppRepository appRepository,
            ICachingAdapter cachingAdapter)
        {
            _cachingAdapter = cachingAdapter;
            _appRepository = appRepository; 
        }

        public async Task<IEnumerable<App>> GetAppsList()
        {
            var cache = await _cachingAdapter.GetAsync("apps");

            if (String.IsNullOrEmpty(cache) == false)
                return JsonConvert
                    .DeserializeObject<IEnumerable<App>>(cache) ?? new List<App>();

            var apps = await _appRepository.GetAll();

            await _cachingAdapter.SetAsync(
                "apps",
                JsonConvert.SerializeObject(apps));

            return apps;
        }
    }
}
