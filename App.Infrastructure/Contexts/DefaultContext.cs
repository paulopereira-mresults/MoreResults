using App.Domain.Entities.Tools;
using App.Infrastructure.Mapping.Tools;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Contexts;

public class DefaultContext : DbContext
{
  public DefaultContext(DbContextOptions<DefaultContext> options)
      : base(options)
  {
  }

  #region Módulo - Tools
  public DbSet<Shortlink> Shortlinks { get; set; }
  public DbSet<ShortlinkAccess> ShortlinksAccesses { get; set; }
  #endregion


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    #region Módulo - Tools
    modelBuilder.ApplyConfiguration(new ShortlinkMap());
    modelBuilder.ApplyConfiguration(new ShortlinkAccessMap());
    #endregion

  }
}
