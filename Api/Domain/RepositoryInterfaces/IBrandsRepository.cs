using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IBrandsRepository
{
  Task<IEnumerable<Brand>> GetAllAsync();
  Task<Brand> GetByID(int id);
  Task<Brand> Create(Brand model);
  Task<Brand> Update(Brand model);
  Task<Brand> Delete(int id);
  bool BrandExists(int id);
}
