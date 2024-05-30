namespace AdsML.Features.Ads.Common;

public class AdsData
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public ContentLabel ContentLabel { get; set; }

    public static AdsData Create(string content, ContentLabel label)
    {
        return new AdsData
        {
            Content = content,
            ContentLabel = label
        };
    }
}
