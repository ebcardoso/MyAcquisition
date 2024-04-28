using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IAcquisitionProductsRepository
{
  Task<AcquisitionProduct> GetByID(int id);
  Task<AcquisitionProduct> Create(AcquisitionProduct model);
  Task<AcquisitionProduct> Delete(int id);
  bool AcquisitionProductExists(int id);
}
