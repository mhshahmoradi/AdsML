using AdsML.Features.Ads.Common;
using Microsoft.EntityFrameworkCore;

namespace AdsML.Common.Persistence;

public class AdsMLDbContext : DbContext
{
    public AdsMLDbContext(DbContextOptions<AdsMLDbContext> options) : base(options)
    {

    }
    public DbSet<AdsData> AdsData => Set<AdsData>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(AdsMLDbContextSchema.DefaultSchema);

        var assembly = typeof(IAssemblyMarker).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}
