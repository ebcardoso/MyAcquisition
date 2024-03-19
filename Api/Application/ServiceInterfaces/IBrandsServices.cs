using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IBrandsServices
{
  Task<IEnumerable<BrandDTO>> GetAllAsync();
  Task<BrandDTO> GetByID(int id);
}
