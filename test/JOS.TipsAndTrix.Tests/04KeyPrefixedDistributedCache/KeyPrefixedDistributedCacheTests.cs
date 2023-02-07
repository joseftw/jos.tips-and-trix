using System.Threading;
using System.Threading.Tasks;
using JOS.TipsAndTrix._04KeyPrefixedDistributedCache;
using Microsoft.Extensions.Caching.Distributed;
using NSubstitute;
using Xunit;

namespace JOS.TipsAndTrix.Tests._04KeyPrefixedDistributedCache;

public class KeyPrefixedDistributedCacheTests
{
    private readonly string _prefix;
    private readonly IDistributedCache _distributedCache;
    private readonly KeyPrefixedDistributedCache _sut;

    public KeyPrefixedDistributedCacheTests()
    {
        _prefix = "my-prefix";
        _distributedCache = Substitute.For<IDistributedCache>();
        _sut = new KeyPrefixedDistributedCache(_distributedCache, _prefix);
    }

    [Fact]
    public void ShouldPrefixKey_Get()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);
        
        _ = _sut.Get(key);

        _distributedCache.Received(1).Get(prefixedKey);
    }

    [Fact]
    public async Task ShouldPrefixKey_GetAsync()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);

        _ = await _sut.GetAsync(key);

        await _distributedCache.Received(1).GetAsync(prefixedKey);
    }

    [Fact]
    public void ShouldPrefixKey_Refresh()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);

        _sut.Refresh(key);

        _distributedCache.Received(1).Refresh(prefixedKey);
    }

    [Fact]
    public async Task ShouldPrefixKey_RefreshAsync()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);

        await _sut.RefreshAsync(key);

        await _distributedCache.Received(1).RefreshAsync(prefixedKey);
    }

    [Fact]
    public async Task ShouldPrefixKey_RefreshAsyncCancellationToken()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);
        var cancellationToken = CancellationToken.None;

        await _sut.RefreshAsync(key, cancellationToken);

        await _distributedCache.Received(1).RefreshAsync(prefixedKey, cancellationToken);
    }

    [Fact]
    public void ShouldPrefixKey_Remove()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);

        _sut.Remove(key);

        _distributedCache.Received(1).Remove(prefixedKey);
    }

    [Fact]
    public async Task ShouldPrefixKey_RemoveAsync()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);

        await _sut.RemoveAsync(key);

        await _distributedCache.Received(1).RemoveAsync(prefixedKey);
    }

    [Fact]
    public async Task ShouldPrefixKey_RemoveAsyncCancellationToken()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);
        var cancellationToken = CancellationToken.None;

        await _sut.RemoveAsync(key, cancellationToken);

        await _distributedCache.Received(1).RemoveAsync(prefixedKey, cancellationToken);
    }

    [Fact]
    public void ShouldPrefixKey_SetExtensionMethod()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);
        var value = "my-value"u8.ToArray();

        _sut.Set(key, value);

        _distributedCache.Received(1).Set(prefixedKey, value, Arg.Any<DistributedCacheEntryOptions>());
    }

    [Fact]
    public void ShouldPrefixKey_Set()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);
        var value = "my-value"u8.ToArray();
        var options = new DistributedCacheEntryOptions();

        _sut.Set(key, value, options);

        _distributedCache.Received(1).Set(prefixedKey, value, options);
    }

    [Fact]
    public async Task ShouldPrefixKey_SetAsyncExtensionMethod()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);
        var value = "my-value"u8.ToArray();

        await _sut.SetAsync(key, value);

        await _distributedCache.Received(1).SetAsync(prefixedKey, value, Arg.Any<DistributedCacheEntryOptions>());
    }

    [Fact]
    public async Task ShouldPrefixKey_SetAsync()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);
        var value = "my-value"u8.ToArray();
        var options = new DistributedCacheEntryOptions();

        await _sut.SetAsync(key, value, options);

        await _distributedCache.Received(1).SetAsync(prefixedKey, value, options, Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task ShouldPrefixKey_SetAsyncCancellationToken()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);
        var value = "my-value"u8.ToArray();
        var options = new DistributedCacheEntryOptions();
        var cancellationToken = CancellationToken.None;

        await _sut.SetAsync(key, value, options, cancellationToken);

        await _distributedCache.Received(1).SetAsync(prefixedKey, value, options, cancellationToken);
    }

    [Fact]
    public async Task ShouldPrefixKey_GetStringAsync()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);

        await _sut.GetStringAsync(key);

        await _distributedCache.Received(1).GetAsync(prefixedKey, Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task ShouldPrefixKey_GetStringAsyncCancellationToken()
    {
        var key = "any-key";
        var prefixedKey = PrefixKey(key);
        var cancellationToken = CancellationToken.None;

        await _sut.GetStringAsync(key, cancellationToken);

        await _distributedCache.Received(1).GetAsync(prefixedKey, cancellationToken);
    }

    private string PrefixKey(string key)
    {
        return $"{_prefix}-{key}";
    }
}
