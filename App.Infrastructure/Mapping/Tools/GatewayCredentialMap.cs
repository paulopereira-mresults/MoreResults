using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entities.Tools;

namespace App.Infrastructure.Mapping.Tools;

public class GatewayCredentialMap : IEntityTypeConfiguration<GatewayCredential>
{
    public void Configure(EntityTypeBuilder<GatewayCredential> builder)
    {
        builder
            .ToTable($"TOOLS_{nameof(GatewayCredential).ToUpper()}");

        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.CreateDate)
            .HasColumnName(nameof(GatewayCredential.CreateDate).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.UpdateDate)
            .HasColumnName(nameof(GatewayCredential.UpdateDate).ToUpper())
            .IsRequired(false)
            .HasDefaultValue(null);

        builder
            .Property(a => a.Key)
            .HasColumnName(nameof(GatewayCredential.Key).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Value)
            .HasColumnName(nameof(GatewayCredential.Value).ToUpper())
            .IsRequired();
    }
}
