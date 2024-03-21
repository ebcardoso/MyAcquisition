using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IProductsRepository
{
  Task<IEnumerable<Product>> GetAllAsync();
  Task<Product> GetByID(int id);
  Task<Product> Create(Product model);
}
