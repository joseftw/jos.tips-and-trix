using System.Net;
using StackExchange.Redis;

namespace JOS.TipsAndTrix._04KeyPrefixedDistributedCache;

public static class RedisOptions
{
    static RedisOptions()
    {
        Options = new ConfigurationOptions
        {
            ClientName = "my-app",
            EndPoints =
            {
                new DnsEndPoint("localhost", 6379)
            },
            Password = "redisftw"
        };
    }
    
    public static ConfigurationOptions Options { get; }
}