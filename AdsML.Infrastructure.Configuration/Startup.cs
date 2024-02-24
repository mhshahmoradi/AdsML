using AdsML.Application.Common.Interfaces;
using AdsML.Domain.Models.DataSetAgg;
using AdsML.Infrastructure.Cache.CacheProvider;
using AdsML.Infrastructure.EFCore;
using AdsML.Infrastructure.EFCore.Repositories;
using AdsML.Infrastructure.ML.Repository;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServiceHost.Common.Mapping;
using Shared.Infrastructure;
using System.Reflection;

namespace AdsML.Infrastructure.Configuration;

public static class Startup
{
    public static void RegisterService(this IServiceCollection services, string? ConnectionString)
    {
        services.AddTransient<IAdsDataRepository, AdsDataRepository>();
        services.AddTransient<IPredictRepository, PredictRepository>();
        services.AddTransient<ICacheProvider, MemoryCacheProvider>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        var assembly = Assembly.GetExecutingAssembly();
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(assembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        services.AddDbContext<AdsMLContext>(x => x.UseSqlServer(ConnectionString));
    }
}
