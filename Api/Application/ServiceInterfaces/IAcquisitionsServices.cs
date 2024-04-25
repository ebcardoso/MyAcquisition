using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Domain.Pagination;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IAcquisitionsServices
{
  Task<PagedList<AcquisitionDTO>> GetAllAsync(int pageNumber, int pageSize);
  Task<AcquisitionDTO> GetByID(int id);
  Task<AcquisitionDTO> Create(AcquisitionPostDTO model);
  Task<AcquisitionDTO> Update(AcquisitionDTO modelDTO);
  Task<AcquisitionDTO> Delete(int id);
  bool AcquisitionExists(int id);
}
