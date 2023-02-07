using System;
using System.Threading.Tasks;
using JOS.TipsAndTrix._04KeyPrefixedDistributedCache;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using StackExchange.Redis;
using Xunit;

namespace JOS.TipsAndTrix.Tests._04KeyPrefixedDistributedCache;

public class InstanceNamePrefixRedisTests
{
    [Fact]
    public async Task CanSaveAndReadKey()
    {
        var services = new ServiceCollection();
        services.AddRedisDistributedCache();
        var sut = services.BuildServiceProvider().GetRequiredService<IDistributedCache>();
        await sut.SetStringAsync("my-key", "josef");
        
        var result = await sut.GetStringAsync("my-key");

        result.ShouldBe("josef");
    }
    
    [Fact]
    public async Task KeyIsPrefixedWithInstanceName()
    {
        var services = new ServiceCollection();
        services.AddRedisDistributedCache();
        var sut = services.BuildServiceProvider().GetRequiredService<IDistributedCache>();
        await sut.SetStringAsync("other-key", "Any");
        using var connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(RedisOptions.Options);
        var database = connectionMultiplexer.GetDatabase();

        var result = await database.KeyExistsAsync("my-appother-key");

        result.ShouldBeTrue();
    }
}