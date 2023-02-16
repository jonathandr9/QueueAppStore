using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueAppStore.Domain.Adapters
{
    public interface ICachingAdapter
    {
        Task SetAsync(string key, string value);
        Task<string> GetAsync(string key);
    }
}
