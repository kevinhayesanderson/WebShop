using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository(IDistributedCache redisCache) : IBasketRepository
    {
        public async Task DeleteBasket(string userName)
        {
            await redisCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart?> GetBasket(string userName)
        {
            var basket = await redisCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonSerializer.Deserialize<ShoppingCart>(new MemoryStream(Encoding.UTF8.GetBytes(basket)));
        }

        public async Task<ShoppingCart?> UpdateBasket(ShoppingCart basket)
        {
            await redisCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket));

            return await GetBasket(basket.UserName);
        }
    }
}