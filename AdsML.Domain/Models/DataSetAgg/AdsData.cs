using AdsML.Domain.Models.Common;

namespace AdsML.Domain.Models.DataSetAgg;

public class AdsData : EntityBase
{
    public string Content { get; private set; }
    public string Label { get; private set; }

    public AdsData(string content, string label)
    {
        Content = content;
        Label = label;
    }
}
