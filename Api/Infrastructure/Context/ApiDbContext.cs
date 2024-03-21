using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Infrastructure.Context;

public class ApiDbContext: DbContext
{
  public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
  {
    // Postgres Timestamps
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
  }

  public DbSet<Brand> Brands { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<User> Users { get; set; }

  public override int SaveChanges()
  {
    AddTimestamps();
    return base.SaveChanges();
  }

  public async Task<int> SaveChangesAsync()
  {
    AddTimestamps();
    return await base.SaveChangesAsync();
  }

  private void AddTimestamps()
  {
    var entities = ChangeTracker.Entries()
        .Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

    foreach (var entity in entities)
    {
      var now = DateTime.UtcNow; // current datetime

      if (entity.State == EntityState.Added)
      {
        ((BaseModel)entity.Entity).CreatedAt = now;
      }
      ((BaseModel)entity.Entity).UpdatedAt = now;
    }
  }
}
