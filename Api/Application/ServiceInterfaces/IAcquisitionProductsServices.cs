using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IAcquisitionProductsServices
{
  Task<AcquisitionProductDTO> GetByID(int id);
  Task<AcquisitionProductDTO> Create(AcquisitionProductPostDTO model);
  Task<AcquisitionProductDTO> Update(AcquisitionProductDTO modelDTO);
  Task<AcquisitionProductDTO> Delete(int id);
  bool AcquisitionProductExists(int id);
}
