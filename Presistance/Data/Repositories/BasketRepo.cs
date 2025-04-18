using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Data.Repositories
{
    public class BasketRepo(IConnectionMultiplexer connectionMultiplexer) : IBasketRepo
    {
        private readonly IDatabase _database = connectionMultiplexer.GetDatabase();

        public async Task<CustomerBasket?> CreateBasketAsync(CustomerBasket Basket, TimeSpan? timetolive = null)
        {
            //create or update
            // Serialize the basket to JSON
            // Set the basket in Redis with the specified key and expiration time
            // Return the basket
            var JsonBasket = JsonSerializer.Serialize(Basket);
            var IsCreatedOrUpdated =await _database.StringSetAsync(Basket.Id, JsonBasket, timetolive ??TimeSpan.FromDays(30));
            return IsCreatedOrUpdated ?await GetBasketAsync(Basket.Id) : null;
        }





        public async Task<bool> DeleteBasketAsync(string id) => await _database.KeyDeleteAsync(id); 

        public async Task<CustomerBasket?> GetBasketAsync(string id) 
        {
            // Get the basket from Redis
            // If the basket is not found, return null
            // If the basket is found, deserialize it and return it


            var value = await _database.StringGetAsync(id);
            if(value.IsNullOrEmpty) return null;
            return JsonSerializer.Deserialize<CustomerBasket?>(value);
        }
    }
}
