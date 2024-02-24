namespace Shared;

public record AppSetting
{
    public static string ConfigurationSectionName => "AppSettings";
    public string ModelFilePath { get; set; }
}
