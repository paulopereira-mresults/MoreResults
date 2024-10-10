using App.Domain.Entities.Core;
using App.Domain.Entities.System;
using App.Domain.Entities.Tools;
using App.Infrastructure.Mapping.Core;
using App.Infrastructure.Mapping.System;
using App.Infrastructure.Mapping.Tools;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Contexts;

public class DefaultContext : DbContext
{
  public DefaultContext(DbContextOptions<DefaultContext> options)
      : base(options)
  {
  }

  #region Módulo Core
  public DbSet<Account> Accounts { get; set; }
  #endregion

  #region Módulo - Tools
  public DbSet<Shortlink> Shortlinks { get; set; }
  public DbSet<ShortlinkAccess> ShortlinksAccesses { get; set; }
  #endregion

  #region Módulo - System
  public DbSet<Plugin> Plugins { get; set; }
  #endregion

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    #region Módulo - Core
    modelBuilder.ApplyConfiguration(new AccountMap());
    #endregion

    #region Módulo - Tools
    modelBuilder.ApplyConfiguration(new ShortlinkMap());
    modelBuilder.ApplyConfiguration(new ShortlinkAccessMap());
    #endregion

    #region Módulo - System
    modelBuilder.ApplyConfiguration(new PluginMap());
    #endregion
  }
}
