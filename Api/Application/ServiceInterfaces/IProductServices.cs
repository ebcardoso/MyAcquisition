using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IProductsServices
{
  Task<IEnumerable<ProductDTO>> GetAllAsync();
  Task<ProductDTO> Create(ProductPostDTO model);
}
