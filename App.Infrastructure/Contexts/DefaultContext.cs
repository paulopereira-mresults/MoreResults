using Microsoft.EntityFrameworkCore;
using App.Domain.Entities.Tools;
using App.Infrastructure.Mapping.Tools;
using App.Domain.Entities.System;
using App.Infrastructure.Mapping.System;

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

    #region Módule - System
    public DbSet<Plugin> Plugins { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Módule - Tools
        modelBuilder.ApplyConfiguration(new ShortlinkMap());
        modelBuilder.ApplyConfiguration(new ShortlinkAccessMap());
        #endregion

        #region Módule - System
        modelBuilder.ApplyConfiguration(new PluginMap());
        #endregion
    }
}
