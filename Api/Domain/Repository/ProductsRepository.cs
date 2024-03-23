using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Infrastructure.Context;

namespace MyAcquisition.Api.Domain.Repositories;

public class ProductsRepository : IProductsRepository
{
  private readonly ApiDbContext _context;

  public ProductsRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Product>> GetAllAsync()
  {
    return await _context.Products.Include(x => x.Brand).ToListAsync();
  }

  public async Task<Product> GetByID(int id)
  {
    var model = await _context.Products.Where(x => x.Id == id)
                                       .Include(x => x.Brand)
                                       .FirstOrDefaultAsync();
    _context.Entry(model).State = EntityState.Detached;
    return model;
  }

  public async Task<Product> Create(Product model)
  {
    _context.Products.Add(model);
    await _context.SaveChangesAsync();
    return model;
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
