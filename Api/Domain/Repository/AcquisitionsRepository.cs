using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.Pagination;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Infrastructure.Context;
using MyAcquisition.Api.Infrastructure.Helpers;

namespace MyAcquisition.Api.Domain.Repositories;

public class AcquisitionsRepository : IAcquisitionsRepository
{
  private readonly ApiDbContext _context;

  public AcquisitionsRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<PagedList<Acquisition>> GetAllAsync(int pageNumber, int pageSize)
  {
    var query = _context.Acquisitions.Include(x => x.Company)
                                     .AsQueryable();
    return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
  }

  public async Task<Acquisition> GetByID(int id)
  {
    var model = await _context.Acquisitions.Where(x => x.Id == id)
                                           .Include(x => x.Company)
                                           .FirstOrDefaultAsync();
    if (model != null)
    {
      _context.Entry(model).State = EntityState.Detached;
    }
    return model;
  }

  public async Task<Acquisition> Create(Acquisition model)
  {
    _context.Acquisitions.Add(model);
    await _context.SaveChangesAsync();
    return await GetByID(model.Id);
  }

  public async Task<Acquisition> Update(Acquisition model)
  {
    _context.Entry(model).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return model;
  }

  public async Task<Acquisition> Delete(int id)
  {
    var model = await GetByID(id);
    if (model != null)
    {
      _context.Acquisitions.Remove(model);
      await _context.SaveChangesAsync();
      return model;
    }
    return null;
  }

  public bool AcquisitionExists(int id)
  {
    return _context.Acquisitions.Any(e => e.Id == id);
  }
}
