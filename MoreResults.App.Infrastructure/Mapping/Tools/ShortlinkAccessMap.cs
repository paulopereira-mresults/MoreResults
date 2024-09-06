using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoreResults.App.Domain.Entities.Tools;

namespace MoreResults.App.Infrastructure.Mapping.Tools;

public class ShortlinkAccessMap : IEntityTypeConfiguration<ShortlinkAccess>
{
    public void Configure(EntityTypeBuilder<ShortlinkAccess> builder)
    {
        builder
            .ToTable("TOOLS_SHORTLINKS_ACCESS");

        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.CreateDate)
            .HasColumnName("CREATEDATE")
            .IsRequired()
            .HasComment("DATA DE CRIAÇÃO DO REGISTRO");

        builder
            .Property(a => a.UpdateDate)
            .HasColumnName("UPDATEDATE")
            .IsRequired(false)
            .HasDefaultValue(null)
            .HasComment("DATA DE ATUALIZAÇÃO DO REGISTRO");

        builder
            .Property(a => a.Ip)
            .HasColumnName("IP")
            .IsRequired(true)
            .HasComment("GUARDA O IP DO USUÁRIO");

        builder
            .Property(a => a.ShortlinkId)
            .HasColumnName("SHORTLINK_ID")
            .IsRequired(true)
            .HasComment("RELACIONA O ACESSO A UM LINK ENCURTADO");

    }
}
