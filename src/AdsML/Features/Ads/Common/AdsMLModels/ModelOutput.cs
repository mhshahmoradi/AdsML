using Microsoft.ML.Data;

namespace AdsML.Features.Ads.Common.AdsMLModels;

public class ModelOutput
{
    [ColumnName(@"PredictedLabel")]
    public string? PredictedLabel { get; set; }

    [ColumnName(@"Score")]
    public float[]? Score { get; set; }

    internal PredictResponse ToPredictResponse()
    {
        return new PredictResponse(this.PredictedLabel, Score[0]);
    }
}
