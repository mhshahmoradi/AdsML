using Microsoft.ML.Data;

namespace AdsML.Application.Common.MLModels;

public class ModelOutput
{
    [ColumnName(@"PredictedLabel")]
    public string? PredictedLabel { get; set; }

    [ColumnName(@"Score")]
    public float[]? Score { get; set; }
}
