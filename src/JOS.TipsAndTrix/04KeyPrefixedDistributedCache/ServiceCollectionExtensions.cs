using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;

namespace JOS.TipsAndTrix._04KeyPrefixedDistributedCache;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRedisDistributedCache(this IServiceCollection services)
    {
        return services.AddStackExchangeRedisCache(options =>
        {
            options.ConfigurationOptions = RedisOptions.Options;
            options.InstanceName = "my-app";
        });
    }

    public static IServiceCollection AddPrefixedDistributedCache(this IServiceCollection services)
    {
        return services.AddSingleton<IDistributedCache>(x =>
        {
            var redisCacheOptions = new RedisCacheOptions { ConfigurationOptions = RedisOptions.Options };
            var redisCache = new RedisCache(redisCacheOptions);
            var keyPrefixedRedisCache = new KeyPrefixedDistributedCache(redisCache, "my-prefix");
            return keyPrefixedRedisCache;
        });
    }
}