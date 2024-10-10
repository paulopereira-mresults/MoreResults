using App.Domain.Entities.Abstractions;
using App.Domain.Entities.System;
using App.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Mapping.System;

public class PluginMap : IEntityTypeConfiguration<Plugin>
{
  public void Configure(EntityTypeBuilder<Plugin> builder)
  {
    builder
        .ToTable($"{SystemModules.SYSTEM}_{nameof(Plugin).ToUpper()}");

    builder
        .HasKey(a => a.Id);

    builder
      .Property(a => a.Id)
      .HasColumnName(nameof(EntityAbstract.Id).ToUpper())
      .HasColumnType("INT")
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
        .HasColumnName(nameof(Plugin.Code).ToUpper())
        .HasColumnType("VARCHAR(5)")
        .IsRequired();

    builder
        .Property(a => a.Resume)
        .HasColumnName(nameof(Plugin.Resume).ToUpper())
        .HasColumnType("VARCHAR(100)")
        .IsRequired();

    builder
        .Property(a => a.Controller)
        .HasColumnName(nameof(Plugin.Controller).ToUpper())
        .HasColumnType("VARCHAR(100)")
        .IsRequired();

    builder
        .Property(a => a.Source)
        .HasColumnName(nameof(Plugin.Source).ToUpper())
        .HasColumnType("TEXT")
        .IsRequired();

    builder
        .Property(a => a.IsActive)
        .HasColumnName(nameof(Plugin.IsActive).ToUpper())
        .HasColumnType("BIT")
        .IsRequired();
  }
}
