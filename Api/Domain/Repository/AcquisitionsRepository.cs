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
}
