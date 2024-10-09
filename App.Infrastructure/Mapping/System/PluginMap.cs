using App.Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Mapping.System;

public class PluginMap : IEntityTypeConfiguration<Plugin>
{
  public void Configure(EntityTypeBuilder<Plugin> builder)
  {
    builder
        .ToTable("SYSTEM_PLUGINS");

    builder
        .HasKey(a => a.Id);

    builder
        .Property(a => a.CreateDate)
        .HasColumnName("CREATEDATE")
        .IsRequired();

    builder
        .Property(a => a.UpdateDate)
        .HasColumnName("UPDATEDATE")
        .IsRequired(false)
        .HasDefaultValue(null);

    builder
        .Property(a => a.Code)
        .HasColumnName("CODE")
        .HasComment("CÓDIGO DO LINK CURTO")
        .IsRequired();

    builder
        .Property(a => a.Resume)
        .HasColumnName("RESUME")
        .IsRequired();

    builder
        .Property(a => a.Controller)
        .HasColumnName("CONTROLLER")
        .IsRequired();

    builder
        .Property(a => a.Source)
        .HasColumnName("SOURCE")
        .IsRequired();

    builder
        .Property(a => a.IsActive)
        .HasColumnName("ISACTIVE")
        .IsRequired();

  }
}
