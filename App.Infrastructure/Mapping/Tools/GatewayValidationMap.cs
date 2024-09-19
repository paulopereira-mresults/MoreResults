using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entities.Tools;

namespace App.Infrastructure.Mapping.Tools;

public class GatewayValidationMap : IEntityTypeConfiguration<GatewayValidation>
{
    public void Configure(EntityTypeBuilder<GatewayValidation> builder)
    {
        builder
            .ToTable($"TOOLS_{nameof(GatewayValidation).ToUpper()}");

        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.CreateDate)
            .HasColumnName(nameof(GatewayValidation.CreateDate).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.UpdateDate)
            .HasColumnName(nameof(GatewayValidation.UpdateDate).ToUpper())
            .IsRequired(false)
            .HasDefaultValue(null);

        builder
            .Property(a => a.ParameterId)
            .HasColumnName(nameof(GatewayValidation.ParameterId).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Resume)
            .HasColumnName(nameof(GatewayValidation.Resume).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Type)
            .HasColumnName(nameof(GatewayValidation.Type).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.ComparisonValue)
            .HasColumnName(nameof(GatewayValidation.ComparisonValue).ToUpper())
            .IsRequired();

    }
}
