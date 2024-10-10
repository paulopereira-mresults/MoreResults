using App.Domain.Entities.Abstractions;
using App.Domain.Entities.Core;
using App.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Mapping.Core;

public class AccountMap : IEntityTypeConfiguration<Account>
{
  public void Configure(EntityTypeBuilder<Account> builder)
  {
    builder
        .ToTable($"{SystemModules.TOOLS}_{nameof(Account).ToUpper()}");

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
      .Property(a => a.Name)
      .HasColumnName(nameof(Account.Name).ToUpper())
      .HasColumnType("VARCHAR(100)")
      .IsRequired(true);

    builder
      .Property(a => a.FantasyName)
      .HasColumnName(nameof(Account.FantasyName).ToUpper())
      .HasColumnType("VARCHAR(100)")
      .IsRequired(true);
  }
}
