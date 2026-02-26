using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.services
{
    public class CartService(IConnectionMultiplexer redis) : ICartService
    {
        private readonly IDatabase _database = redis.GetDatabase();
        public async Task<bool> DeleteCartAsync(string key)
        {
            return await _database.KeyDeleteAsync(key);
        }

        public async Task<ShoppingCart?> GetCartAsync(string key)
        {
            var data = await _database.StringGetAsync(key);
            
            return data.IsNullOrEmpty ? null : System.Text.Json.JsonSerializer.Deserialize<ShoppingCart>(data!);
        }


        public async Task<ShoppingCart?> SetCartAsync(ShoppingCart cart)
        {
            var created = _database.StringSet(cart.Id, System.Text.Json.JsonSerializer.Serialize(cart), TimeSpan.FromDays(7));

            if (!created) return null;

            return await GetCartAsync(cart.Id);
        }
    }
}