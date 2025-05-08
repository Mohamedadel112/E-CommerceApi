using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Data.Repositories
{
    public class CacheRepo(IConnectionMultiplexer connectionMultiplexer) : ICacheReepo
    {
        private readonly IDatabase _database = connectionMultiplexer.GetDatabase();
        public async Task<string?> GetAsync(string key)
        {
           var value = await _database.StringGetAsync(key);
            return value.IsNullOrEmpty ? default : value;
        }

        public async Task SetAsync(string key, object Value, TimeSpan duration)
        {
            var Serializeobj = JsonSerializer.Serialize(Value);
            await _database.StringSetAsync(key, Serializeobj, duration);
        }
    }
}
