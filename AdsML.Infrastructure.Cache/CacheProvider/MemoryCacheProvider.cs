using AdsML.Application.Common.Interfaces;
using AdsML.Application.Common.ViewModels;
using Microsoft.Extensions.Caching.Memory;

namespace AdsML.Infrastructure.Cache.CacheProvider;

public class MemoryCacheProvider(IMemoryCache cache)
    : ICacheProvider
{
    private readonly IMemoryCache _cache = cache;

    public (bool Result, PredictViewModel Data) TryGet(string key)
    {
        var result = _cache.TryGetValue(key, out PredictViewModel viewModel);
        return (result, viewModel);
    }

    public void Remove(string key)
    {
        _cache.Remove(key);
    }

    public bool Set(string key, PredictViewModel value, DateTime expirationDate)
    {
        try
        {
            _cache.Set(key, value, expirationDate);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Set(string key, PredictViewModel value)
    {
        try
        {
            _cache.Set(key, value);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
