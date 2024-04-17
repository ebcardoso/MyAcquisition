using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Infrastructure.Context;
using MyAcquisition.Api.Infrastructure.Helpers;
using MyAcquisition.Api.Domain.Pagination;

namespace MyAcquisition.Api.Domain.Repositories;

public class ProductsRepository : IProductsRepository
{
  private readonly ApiDbContext _context;

  public ProductsRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<PagedList<Product>> GetAllAsync(int pageNumber, int pageSize)
  {
    var query = _context.Products.Include(x => x.Brand)
                                 .Include(x => x.Company)
                                 .AsQueryable();
    return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
  }

  public async Task<Product> GetByID(int id)
  {
    var model = await _context.Products.Where(x => x.Id == id)
                                       .Include(x => x.Brand)
                                       .Include(x => x.Company)
                                       .FirstOrDefaultAsync();
    _context.Entry(model).State = EntityState.Detached;
    return model;
  }

  public async Task<Product> Create(Product model)
  {
    _context.Products.Add(model);
    await _context.SaveChangesAsync();
    return await GetByID(model.Id);
  }

  public async Task<Product> Update(Product model)
  {
    _context.Entry(model).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return model;
  }

  public async Task<Product> Delete(int id)
  {
    var model = await GetByID(id);
    if (model != null)
    {
      _context.Products.Remove(model);
      await _context.SaveChangesAsync();
      return model;
    }
    return null;
  }

  public bool ProductExists(int id)
  {
    return _context.Products.Any(e => e.Id == id);
  }
}
