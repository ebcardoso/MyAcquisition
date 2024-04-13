using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Infrastructure.Context;

namespace MyAcquisition.Api.Domain.Repositories;

public class CompaniesRepository : ICompaniesRepository
{
  private readonly ApiDbContext _context;

  public CompaniesRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<Company> Create(Company model)
  {
    _context.Companies.Add(model);
    await _context.SaveChangesAsync();
    return model;
  }
}
