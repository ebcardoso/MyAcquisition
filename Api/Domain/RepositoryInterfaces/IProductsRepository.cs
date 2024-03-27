using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.Pagination;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IProductsRepository
{
  Task<PagedList<Product>> GetAllAsync(int pageNumber, int pageSize);
  Task<Product> GetByID(int id);
  Task<Product> Create(Product model);
  Task<Product> Update(Product model);
  Task<Product> Delete(int id);
  bool ProductExists(int id);
}
