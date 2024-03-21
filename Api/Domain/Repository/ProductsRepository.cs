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

  public async Task<Product> Create(Product model)
  {
    _context.Products.Add(model);
    await _context.SaveChangesAsync();
    return model;
  }
}
