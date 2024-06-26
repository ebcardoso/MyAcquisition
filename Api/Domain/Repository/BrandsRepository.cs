using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Infrastructure.Context;
using MyAcquisition.Api.Domain.Pagination;
using MyAcquisition.Api.Infrastructure.Helpers;

namespace MyAcquisition.Api.Domain.Repositories;

public class BrandsRepository : IBrandsRepository
{
  private readonly ApiDbContext _context;

  public BrandsRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<PagedList<Brand>> GetAllAsync(int pageNumber, int pageSize)
  {
    var query = _context.Brands.AsQueryable();
    return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
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

  public async Task<Brand> Update(Brand model)
  {
    _context.Entry(model).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return model;
  }

  public async Task<Brand> Delete(int id)
  {
    var model = await GetByID(id);
    if (model != null)
    {
      _context.Brands.Remove(model);
      await _context.SaveChangesAsync();
      return model;
    }
    return null;
  }

  public bool BrandExists(int id)
  {
    return _context.Brands.Any(e => e.Id == id);
  }
}
