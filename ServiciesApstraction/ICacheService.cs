using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciesApstraction
{
    public interface ICacheService
    {
        Task SetCacheAsync(string key, object Value, TimeSpan duration);

        Task<string?> GetCacheAsync(string key);
    }
}
