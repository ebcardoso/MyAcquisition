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

  public async Task<Brand> GetByID(int id)
  {
    var model = await _context.Brands.Where(x => x.Id == id).FirstOrDefaultAsync();
    return model;
  }

  public async Task<Brand> Create(Brand model)
  {
    _context.Brands.Add(model);
    await _context.SaveChangesAsync();
    return model;
  }
}
