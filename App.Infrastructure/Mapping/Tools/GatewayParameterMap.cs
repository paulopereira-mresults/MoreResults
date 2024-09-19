using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entities.Tools;

namespace App.Infrastructure.Mapping.Tools;

public class GatewayParameterMap : IEntityTypeConfiguration<GatewayParameter>
{
    public void Configure(EntityTypeBuilder<GatewayParameter> builder)
    {
        builder
            .ToTable($"TOOLS_{nameof(GatewayParameter).ToUpper()}");

        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.CreateDate)
            .HasColumnName(nameof(GatewayParameter.CreateDate).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.UpdateDate)
            .HasColumnName(nameof(GatewayParameter.UpdateDate).ToUpper())
            .IsRequired(false)
            .HasDefaultValue(null);

        builder
            .Property(a => a.Name)
            .HasColumnName(nameof(GatewayParameter.Name).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Resume)
            .HasColumnName(nameof(GatewayParameter.Resume).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Type)
            .HasColumnName(nameof(GatewayParameter.Type).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Value)
            .HasColumnName(nameof(GatewayParameter.Value).ToUpper())
            .IsRequired();

        builder
            .HasMany(x => x.Validations)
            .WithOne(x => x.ParameterInstance)
            .HasForeignKey(x => x.ParameterId);
    }
}
