using Microsoft.EntityFrameworkCore;

namespace MyAcquisition.Api.Infrastructure.Context;

public class ApiDbContext: DbContext
{
  public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
  {
  }
}
