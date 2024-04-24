using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IAcquisitionsRepository
{
  Task<Acquisition> GetByID(int id);
  Task<Acquisition> Create(Acquisition model);
  Task<Acquisition> Update(Acquisition model);
  Task<Acquisition> Delete(int id);
  bool AcquisitionExists(int id);
}
