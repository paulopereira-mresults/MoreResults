using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entities.Tools;

namespace App.Infrastructure.Mapping.Tools;

public class ShortlinkMap : IEntityTypeConfiguration<Shortlink>
{
    public void Configure(EntityTypeBuilder<Shortlink> builder)
    {
        builder
            .ToTable("TOOLS_SHORTLINKS");

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
            .Property(a => a.Code)
            .HasColumnName("CODE")
            .HasComment("CÓDIGO DO LINK CURTO")
            .IsRequired();

        builder
            .Property(a => a.Resume)
            .HasColumnName("RESUME")
            .HasComment("DESCRIÇÃO RESUMIDA OU RESUMO A RESPEITO DO LINK")
            .IsRequired();

        builder
            .Property(a => a.Link)
            .HasColumnName("LINK")
            .HasComment("LINK PARA O QUAL O USUÁRIO SERÁ REDIRECIONADO")
            .IsRequired();

        builder
            .HasMany(x => x.Accesses)
            .WithOne(x => x.Shortlink)
            .HasForeignKey(x => x.ShortlinkId);
    }
}
