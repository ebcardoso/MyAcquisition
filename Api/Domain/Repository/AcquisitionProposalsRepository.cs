using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Infrastructure.Context;

namespace MyAcquisition.Api.Domain.Repositories;

public class AcquisitionProposalsRepository : IAcquisitionProposalsRepository
{
  private readonly ApiDbContext _context;

  public AcquisitionProposalsRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<AcquisitionProposal> GetByID(int id)
  {
    var model = await _context.AcquisitionProposals.Where(x => x.Id == id)
                                                   .Include(x => x.AcquisitionProduct)
                                                   .Include(x => x.User)
                                                   .FirstOrDefaultAsync();
    _context.Entry(model).State = EntityState.Detached;
    return model;
  }

  public async Task<AcquisitionProposal> Create(AcquisitionProposal model)
  {
    _context.AcquisitionProposals.Add(model);
    await _context.SaveChangesAsync();
    return await GetByID(model.Id);
  }
}
