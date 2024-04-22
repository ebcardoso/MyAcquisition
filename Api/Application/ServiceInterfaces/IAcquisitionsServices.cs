using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IAcquisitionsServices
{
  Task<AcquisitionDTO> GetByID(int id);
}
