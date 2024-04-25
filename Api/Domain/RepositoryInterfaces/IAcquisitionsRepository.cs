using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.Pagination;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IAcquisitionsRepository
{
  Task<PagedList<Acquisition>> GetAllAsync(int pageNumber, int pageSize);
  Task<Acquisition> GetByID(int id);
  Task<Acquisition> Create(Acquisition model);
  Task<Acquisition> Update(Acquisition model);
  Task<Acquisition> Delete(int id);
  bool AcquisitionExists(int id);
}
