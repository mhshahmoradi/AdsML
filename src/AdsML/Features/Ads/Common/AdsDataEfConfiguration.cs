using AdsML.Common.Persistence;

namespace AdsML.Features.Ads.Common;

public class AdsDataEfConfiguration : IEntityTypeConfiguration<AdsData>
{
    public void Configure(EntityTypeBuilder<AdsData> builder)
    {
        builder.ToTable(AdsMLDbContextSchema.AdsData.TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Content)
        .HasMaxLength(4816)
        .IsRequired();

        builder.Property(x => x.ContentLabel)
        .IsRequired();
    }
}
