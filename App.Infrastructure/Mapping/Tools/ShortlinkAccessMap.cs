using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entities.Tools;

namespace App.Infrastructure.Mapping.Tools;

public class ShortlinkAccessMap : IEntityTypeConfiguration<ShortlinkAccess>
{
    public void Configure(EntityTypeBuilder<ShortlinkAccess> builder)
    {
        builder
            .ToTable($"TOOLS_{nameof(ShortlinkAccess).ToUpper()}");

        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.CreateDate)
            .HasColumnName(nameof(ShortlinkAccess.CreateDate).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.UpdateDate)
            .HasColumnName(nameof(ShortlinkAccess.UpdateDate).ToUpper())
            .IsRequired(false)
            .HasDefaultValue(null);

        builder
            .Property(a => a.Ip)
            .HasColumnName(nameof(ShortlinkAccess.Ip).ToUpper())
            .IsRequired(true);

        builder
            .Property(a => a.ShortlinkId)
            .HasColumnName(nameof(ShortlinkAccess.ShortlinkId).ToUpper())
            .IsRequired(true);

    }
}
