using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IAcquisitionProductsRepository
{
  Task<AcquisitionProduct> Create(AcquisitionProduct model);
}
