using Domain.Contracts;
using ServiciesApstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    internal class CacheService(ICacheReepo cacherepo) : ICacheService
    {
        public async Task<string?> GetCacheAsync(string key) => await cacherepo.GetAsync(key);


        public async Task SetCacheAsync(string key, object Value, TimeSpan duration) => await cacherepo.SetAsync(key, Value, duration);
    
    }
}
