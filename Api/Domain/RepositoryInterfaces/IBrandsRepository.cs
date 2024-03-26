using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.Pagination;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IBrandsRepository
{
  Task<PagedList<Brand>> GetAllAsync(int pageNumber, int pageSize);
  Task<Brand> GetByID(int id);
  Task<Brand> Create(Brand model);
  Task<Brand> Update(Brand model);
  Task<Brand> Delete(int id);
  bool BrandExists(int id);
}
