using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entities.Tools;

namespace App.Infrastructure.Mapping.Tools;

public class GatewayCategoryMap : IEntityTypeConfiguration<GatewayCategory>
{
    public void Configure(EntityTypeBuilder<GatewayCategory> builder)
    {
        builder
            .ToTable($"TOOLS_{nameof(GatewayCategory).ToUpper()}");

        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.CreateDate)
            .HasColumnName(nameof(GatewayCategory.CreateDate).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.UpdateDate)
            .HasColumnName(nameof(GatewayCategory.UpdateDate).ToUpper())
            .IsRequired(false)
            .HasDefaultValue(null);

        builder
            .Property(a => a.Name)
            .HasColumnName(nameof(GatewayCategory.Name).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Description)
            .HasColumnName(nameof(GatewayCategory.Description).ToUpper())
            .IsRequired();

        builder
            .HasMany(x => x.Gateways)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}
