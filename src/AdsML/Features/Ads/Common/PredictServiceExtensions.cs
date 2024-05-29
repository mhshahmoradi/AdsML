using Microsoft.Extensions.ML;

namespace AdsML.Features.Ads.Common;

public static class PredictServiceExtensions
{
    public static PredictionEnginePoolBuilder<TData, TPrediction> LoadModel<TData, TPrediction>(this PredictionEnginePoolBuilder<TData, TPrediction> builder, IConfiguration configuration) where TData : class where TPrediction : class, new()
    {
        var modelFilePath = configuration.GetValue<string>("AppSettings:ModelFilePath");
        return builder.FromFile(string.Empty, modelFilePath, watchForChanges: false);
    }
}
