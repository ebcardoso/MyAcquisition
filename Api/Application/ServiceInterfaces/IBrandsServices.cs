using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Domain.Pagination;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IBrandsServices
{
  Task<PagedList<BrandDTO>> GetAllAsync(int pageNumber, int pageSize);
  Task<BrandDTO> GetByID(int id);
  Task<BrandDTO> Create(BrandDTO model);
  Task<BrandDTO> Update(BrandDTO modelDTO);
  Task<BrandDTO> Delete(int id);
  bool BrandExists(int id);
}
