using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Infrastructure.Context;

namespace MyAcquisition.Api.Domain.Repositories;

public class CompanyUsersRepository : ICompanyUsersRepository
{
  private readonly ApiDbContext _context;

  public CompanyUsersRepository(ApiDbContext context)
  {
    _context = context;
  }
  
  public async Task<CompanyUser> Create(CompanyUser model)
  {
    _context.CompanyUsers.Add(model);
    await _context.SaveChangesAsync();
    return model;
  }
}
