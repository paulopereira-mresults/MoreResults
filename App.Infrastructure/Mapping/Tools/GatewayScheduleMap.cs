using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entities.Tools;

namespace App.Infrastructure.Mapping.Tools;

public class GatewayScheduleMap : IEntityTypeConfiguration<GatewaySchedule>
{
    public void Configure(EntityTypeBuilder<GatewaySchedule> builder)
    {
        builder
            .ToTable($"TOOLS_{nameof(GatewaySchedule).ToUpper()}");

        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.CreateDate)
            .HasColumnName(nameof(GatewaySchedule.CreateDate).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.UpdateDate)
            .HasColumnName(nameof(GatewaySchedule.UpdateDate).ToUpper())
            .IsRequired(false)
            .HasDefaultValue(null);

        builder
            .Property(a => a.GatewayId)
            .HasColumnName(nameof(GatewaySchedule.GatewayId).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Resume)
            .HasColumnName(nameof(GatewaySchedule.Resume).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Cron)
            .HasColumnName(nameof(GatewaySchedule.Cron).ToUpper())
            .IsRequired();

        builder
            .Property(a => a.Job)
            .HasColumnName(nameof(GatewaySchedule.Job).ToUpper())
            .IsRequired();

    }
}
