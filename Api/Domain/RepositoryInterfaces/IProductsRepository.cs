using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IProductsRepository
{
  Task<Product> Create(Product model);
}
