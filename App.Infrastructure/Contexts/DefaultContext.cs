using Microsoft.EntityFrameworkCore;
using App.Domain.Entities.Tools;
using App.Infrastructure.Mapping.Tools;

namespace App.Infrastructure.Contexts;

public class DefaultContext : DbContext
{
    public DefaultContext(DbContextOptions<DefaultContext> options)
        : base(options)
    {
    }

    #region Módule - Tools
    public DbSet<Shortlink> Shortlinks { get; set; }
    public DbSet<ShortlinkAccess> ShortlinksAccesses { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ShortlinkMap());
        modelBuilder.ApplyConfiguration(new ShortlinkAccessMap());

        // Outras configurações
    }
}
