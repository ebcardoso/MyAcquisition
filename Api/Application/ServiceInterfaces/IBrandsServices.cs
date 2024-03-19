using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IBrandsServices
{
  Task<IEnumerable<BrandDTO>> GetAllAsync();
  Task<BrandDTO> GetByID(int id);
  Task<BrandDTO> Create(BrandDTO model);
  Task<BrandDTO> Update(BrandDTO modelDTO);
  bool BrandExists(int id);
}
