using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IAcquisitionProductsServices
{
  Task<AcquisitionProductDTO> Create(AcquisitionProductPostDTO model);
}
