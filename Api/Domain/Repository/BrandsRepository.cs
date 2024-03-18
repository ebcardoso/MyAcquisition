using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Infrastructure.Context;

namespace MyAcquisition.Api.Domain.Repositories;

public class BrandsRepository : IBrandsRepository
{
  private readonly ApiDbContext _context;

  public BrandsRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Brand>> GetAllAsync()
  {
    return await _context.Brands.ToListAsync();
  }
}
