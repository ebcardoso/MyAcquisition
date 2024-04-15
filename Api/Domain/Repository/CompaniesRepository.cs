using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.Pagination;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Infrastructure.Context;
using MyAcquisition.Api.Infrastructure.Helpers;

namespace MyAcquisition.Api.Domain.Repositories;

public class CompaniesRepository : ICompaniesRepository
{
  private readonly ApiDbContext _context;

  public CompaniesRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<PagedList<Company>> GetAllAsync(int pageNumber, int pageSize)
  {
    var query = _context.Companies.AsQueryable();
    return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
  }

  public async Task<Company> GetByID(int id)
  {
    var model = await _context.Companies.Where(x => x.Id == id).FirstOrDefaultAsync();
    return model;
  }

  public async Task<Company> Update(Company model)
  {
    _context.Entry(model).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return model;
  }

  public async Task<Company> Create(Company model)
  {
    _context.Companies.Add(model);
    await _context.SaveChangesAsync();
    return model;
  }

  public async Task<Company> Delete(int id)
  {
    var model = await GetByID(id);
    if (model != null)
    {
      _context.Companies.Remove(model);
      await _context.SaveChangesAsync();
      return model;
    }
    return null;
  }

  public bool CompanyExists(int id)
  {
    return _context.Companies.Any(e => e.Id == id);
  }
}
