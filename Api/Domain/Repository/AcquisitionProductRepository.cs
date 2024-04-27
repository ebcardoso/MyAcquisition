using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.Pagination;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Infrastructure.Context;

namespace MyAcquisition.Api.Domain.Repositories;

public class AcquisitionProductsRepository : IAcquisitionProductsRepository
{
  private readonly ApiDbContext _context;

  public AcquisitionProductsRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<AcquisitionProduct> GetByID(int id)
  {
    var model = await _context.AcquisitionProducts.Where(x => x.Id == id)
                                                  .Include(x => x.Acquisition)
                                                  .Include(x => x.Product)
                                                  .FirstOrDefaultAsync();
    return model;
  }

  public async Task<AcquisitionProduct> Create(AcquisitionProduct model)
  {
    _context.AcquisitionProducts.Add(model);
    await _context.SaveChangesAsync();
    return await GetByID(model.Id);
  }
}