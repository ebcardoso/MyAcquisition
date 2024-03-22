using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IProductsServices
{
  Task<IEnumerable<ProductDTO>> GetAllAsync();
  Task<ProductDTO> GetByID(int id);
  Task<ProductDTO> Create(ProductPostDTO model);
  Task<ProductDTO> Delete(int id);
  bool ProductExists(int id);
}
