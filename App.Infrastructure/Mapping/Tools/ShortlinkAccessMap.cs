using App.Domain.Entities.Abstractions;
using App.Domain.Entities.Tools;
using App.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Mapping.Tools;

public class ShortlinkAccessMap : IEntityTypeConfiguration<ShortlinkAccess>
{
  public void Configure(EntityTypeBuilder<ShortlinkAccess> builder)
  {
    builder
        .ToTable($"{SystemModules.TOOLS}_{nameof(ShortlinkAccess).ToUpper()}");

    builder
        .HasKey(a => a.Id);

    builder
      .Property(a => a.Id)
      .HasColumnType(nameof(EntityAbstract.Id).ToUpper())
      .IsRequired();

    builder
      .Property(a => a.CreateDate)
      .HasColumnName(nameof(EntityAbstract.CreateDate).ToUpper())
      .HasColumnType("DATETIME")
      .IsRequired();

    builder
      .Property(a => a.UpdateDate)
      .HasColumnName(nameof(EntityAbstract.UpdateDate).ToUpper())
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
