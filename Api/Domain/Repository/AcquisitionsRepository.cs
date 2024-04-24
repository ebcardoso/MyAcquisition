using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Infrastructure.Context;

namespace MyAcquisition.Api.Domain.Repositories;

public class AcquisitionsRepository : IAcquisitionsRepository
{
  private readonly ApiDbContext _context;

  public AcquisitionsRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<Acquisition> GetByID(int id)
  {
    var model = await _context.Acquisitions.Where(x => x.Id == id)
                                           .Include(x => x.Company)
                                           .FirstOrDefaultAsync();
    _context.Entry(model).State = EntityState.Detached;
    return model;
  }

  public async Task<Acquisition> Create(Acquisition model)
  {
    _context.Acquisitions.Add(model);
    await _context.SaveChangesAsync();
    return await GetByID(model.Id);
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
