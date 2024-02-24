using AdsML.Application.Common.ViewModels;

namespace AdsML.Application.Common.Interfaces;

public interface ICacheProvider
{
    public bool Set(string key, PredictViewModel value, DateTime expirationDate);
    public bool Set(string key, PredictViewModel value);
    void Remove(string key);
    PredictViewModel Get(string key);
}
