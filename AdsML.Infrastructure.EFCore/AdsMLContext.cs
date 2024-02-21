using AdsML.Domain.Models.DataSetAgg;
using AdsML.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AdsML.Infrastructure.EFCore;

public class AdsMLContext(DbContextOptions<AdsMLContext> options) : DbContext(options)
{
   public DbSet<AdsData> AdsData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(AdsDataMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}
