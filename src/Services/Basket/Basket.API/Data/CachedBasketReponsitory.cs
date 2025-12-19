using System.Text.Json;
using Basket.API.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Data;

public class CachedBasketReponsitory(IBasketReponsitory reponsitory, IDistributedCache cache) : IBasketReponsitory
{
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellation = default)
    {
        var cachebasket = await cache.GetStringAsync(userName, cancellation);
        if(!string.IsNullOrEmpty(cachebasket))
            return JsonSerializer.Deserialize<ShoppingCart>(cachebasket);
        var basket = await reponsitory.GetBasket(userName,cancellation);
        await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellation);
        return basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellation = default)
    {
        await reponsitory.StoreBasket(basket, cancellation);
        await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellation);
        return basket;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellation = default)
    {
        await reponsitory.DeleteBasket(userName, cancellation);
        await cache.RemoveAsync(userName, cancellation);
        return true;
    }
}