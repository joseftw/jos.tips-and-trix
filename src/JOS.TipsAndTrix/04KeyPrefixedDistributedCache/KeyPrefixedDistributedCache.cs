using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace JOS.TipsAndTrix._04KeyPrefixedDistributedCache;

public class KeyPrefixedDistributedCache : IDistributedCache
{
    private readonly IDistributedCache _distributedCache;
    private readonly string _prefix;

    public KeyPrefixedDistributedCache(IDistributedCache distributedCache, string prefix)
    {
        _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        _prefix = prefix ?? throw new ArgumentNullException(nameof(prefix));
    }

    public byte[]? Get(string key)
    {
        var prefixedKey = PrefixKey(key);
        return _distributedCache.Get(prefixedKey);
    }

    public Task<byte[]?> GetAsync(string key, CancellationToken token = new())
    {
        var prefixedKey = PrefixKey(key);
        return _distributedCache.GetAsync(prefixedKey, token);
    }

    public void Refresh(string key)
    {
        var prefixedKey = PrefixKey(key);
        _distributedCache.Refresh(prefixedKey);
    }

    public Task RefreshAsync(string key, CancellationToken token = new())
    {
        var prefixedKey = PrefixKey(key);
        return _distributedCache.RefreshAsync(prefixedKey, token);
    }

    public void Remove(string key)
    {
        var prefixedKey = PrefixKey(key);
        _distributedCache.Remove(prefixedKey);
    }

    public Task RemoveAsync(string key, CancellationToken token = new())
    {
        var prefixedKey = PrefixKey(key);
        return _distributedCache.RemoveAsync(prefixedKey, token);
    }

    public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    {
        var prefixedKey = PrefixKey(key);
        _distributedCache.Set(prefixedKey, value, options);
    }

    public Task SetAsync(
        string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = new())
    {
        var prefixedKey = PrefixKey(key);
        return _distributedCache.SetAsync(prefixedKey, value, options, token);
    }

    private string PrefixKey(string key)
    {
        return $"{_prefix}-{key}";
    }
}
