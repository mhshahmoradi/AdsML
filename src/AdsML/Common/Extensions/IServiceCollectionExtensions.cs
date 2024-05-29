namespace AdsML.Common.Extensions;

internal static class IServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDbContexts(this IServiceCollection services, IConfiguration configuration)
    {


        return services;
    }

    public static IServiceCollection ConfigureValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

        return services;
    }
}
