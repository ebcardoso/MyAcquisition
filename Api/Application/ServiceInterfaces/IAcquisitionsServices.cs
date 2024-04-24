using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IAcquisitionsServices
{
  Task<AcquisitionDTO> GetByID(int id);
  Task<AcquisitionDTO> Create(AcquisitionPostDTO model);
  Task<AcquisitionDTO> Update(AcquisitionDTO modelDTO);
  Task<AcquisitionDTO> Delete(int id);
  bool AcquisitionExists(int id);
}
