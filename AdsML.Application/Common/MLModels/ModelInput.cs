using Microsoft.ML.Data;

namespace AdsML.Application.Common.MLModels;

public class ModelInput
{
    [LoadColumn(0)]
    [ColumnName(@"Label")]
    public string? Label { get; set; }
    [LoadColumn(1)]
    [ColumnName(@"Content")]
    public string? Content { get; set; }

    public ModelInput(string? label, string? content)
    {
        Label = label;
        Content = content;
    }

    public ModelInput(string? content)
    {
        Content = content;
    }
}
