using AdsML.Features.Ads.Common;
using ServiceCollector.Abstractions;

namespace AdsML.Features.Ads;

public abstract class FeatureManager
{
    public const string EndpointTagName = "Predict";
    public const string Prefix = "/Ads";

    public class ServiceManager : IServiceDiscovery
    {
        public void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<PredictService>();
        }
    }
}
