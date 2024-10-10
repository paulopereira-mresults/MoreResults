using App.Domain.Entities.Abstractions;
using App.Domain.Entities.Tools;
using App.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Mapping.Tools;

public class ShortlinkMap : IEntityTypeConfiguration<Shortlink>
{
  public void Configure(EntityTypeBuilder<Shortlink> builder)
  {
    builder
        .ToTable($"{SystemModules.TOOLS}_{nameof(Shortlink).ToUpper()}");

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
        .Property(a => a.Code)
        .HasColumnType("VARCHAR(5)")
        .HasColumnName(nameof(Shortlink.Code).ToUpper())
        .IsRequired();

    builder
        .Property(a => a.Resume)
        .HasColumnType("VARCHAR(100)")
        .HasColumnName(nameof(Shortlink.Resume).ToUpper())
        .IsRequired();

    builder
        .Property(a => a.Link)
        .HasColumnType("VARCHAR(150)")
        .HasColumnName(nameof(Shortlink.Link).ToUpper())
        .IsRequired();

    builder
        .HasMany(x => x.Accesses)
        .WithOne(x => x.Shortlink)
        .HasForeignKey(x => x.ShortlinkId);
  }
}
