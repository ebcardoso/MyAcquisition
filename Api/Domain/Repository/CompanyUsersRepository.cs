using Microsoft.EntityFrameworkCore;
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

  public async Task<CompanyUser> GetByID(int id)
  {
    var model = await _context.CompanyUsers.Where(x => x.Id == id)
                                           .Include(x => x.Company)
                                           .Include(x => x.User)
                                           .FirstOrDefaultAsync();
    return model;
  }
  
  public async Task<CompanyUser> Create(CompanyUser model)
  {
    _context.CompanyUsers.Add(model);
    await _context.SaveChangesAsync();
    return model;
  }

  public async Task<CompanyUser> Delete(int id)
  {
    var model = await GetByID(id);
    if (model != null)
    {
      _context.CompanyUsers.Remove(model);
      await _context.SaveChangesAsync();
      return model;
    }
    return null;
  }

  public bool CompanyUserExists(int id)
  {
    return _context.CompanyUsers.Any(x => x.Id == id);
  }
}
