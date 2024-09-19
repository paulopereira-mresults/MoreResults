using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entities.Tools;

namespace App.Infrastructure.Mapping.Tools;

public class GatewayMap : IEntityTypeConfiguration<Gateway>
{
    public void Configure(EntityTypeBuilder<Gateway> builder)
    {
        builder
            .ToTable($"TOOLS_{nameof(Gateway).ToUpper()}");

        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.CreateDate)
            .HasColumnName(nameof(Gateway.CreateDate).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.UpdateDate)
            .HasColumnName(nameof(Gateway.UpdateDate).ToUpper())
            .IsRequired(false)
            .HasDefaultValue(null);

        builder
            .Property(a => a.CategoryId)
            .HasColumnName(nameof(Gateway.CategoryId).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.IsActive)
            .HasColumnName(nameof(Gateway.IsActive).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Code)
            .HasColumnName(nameof(Gateway.Code).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Title)
            .HasColumnName(nameof(Gateway.Title).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Resume)
            .HasColumnName(nameof(Gateway.Resume).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Type)
            .HasColumnName(nameof(Gateway.Type).ToUpper())
            .IsRequired();

        builder
            .HasMany(x => x.Parameters)
            .WithOne(x => x.GatewayInstance)
            .HasForeignKey(x => x.GatewayId);
    }
}
