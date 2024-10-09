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
      .Property(a => a.Id)
      .HasColumnType("ID")
      .IsRequired()
      .UseIdentityColumn(1, 1);

    builder
      .Property(a => a.CreateDate)
      .HasColumnName(nameof(Shortlink.CreateDate).ToUpper())
      .HasColumnType("DATETIME")
      .IsRequired();

    builder
      .Property(a => a.UpdateDate)
      .HasColumnName(nameof(Shortlink.UpdateDate).ToUpper())
      .HasColumnType("DATETIME")
      .IsRequired(false)
      .HasDefaultValue(null);

    builder
      .Property(a => a.Ip)
      .HasColumnType("VARCHAR(50)")
      .HasColumnName(nameof(ShortlinkAccess.Ip).ToUpper())
      .IsRequired(true);

    builder
      .Property(a => a.ShortlinkId)
      .HasColumnType("INT")
      .HasColumnName(nameof(ShortlinkAccess.ShortlinkId).ToUpper())
      .IsRequired(true);

  }
}
