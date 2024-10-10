using App.Domain.Entities.Core;
using App.Domain.Entities.Tools;
using App.Infrastructure.Mapping.Core;
using App.Infrastructure.Mapping.Tools;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Contexts;

public class DefaultContext : DbContext
{
  public DefaultContext(DbContextOptions<DefaultContext> options)
      : base(options)
  {
  }

  #region Tools
  public DbSet<Shortlink> Shortlinks { get; set; }
  public DbSet<ShortlinkAccess> ShortlinksAccesses { get; set; }
  #endregion

  #region Core
  public DbSet<Account> Accounts { get; set; }
  #endregion

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    #region Tools
    modelBuilder.ApplyConfiguration(new ShortlinkMap());
    modelBuilder.ApplyConfiguration(new ShortlinkAccessMap());
    #endregion

    #region Core
    modelBuilder.ApplyConfiguration(new AccountMap());
    #endregion
  }
}
