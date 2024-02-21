using AdsML.Domain.Models.DataSetAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsML.Infrastructure.EFCore.Mapping;

public class AdsDataMapping : IEntityTypeConfiguration<AdsData>
{
    public void Configure(EntityTypeBuilder<AdsData> builder)
    {
        builder.ToTable("AdsData");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Label).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Content).HasMaxLength(2048).IsRequired();
    }
}
