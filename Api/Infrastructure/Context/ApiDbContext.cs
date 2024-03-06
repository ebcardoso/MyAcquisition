using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Infrastructure.Context;

public class ApiDbContext: DbContext
{
  public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
}
