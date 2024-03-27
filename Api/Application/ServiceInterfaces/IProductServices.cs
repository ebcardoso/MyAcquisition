using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Domain.Pagination;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IProductsServices
{
  Task<PagedList<ProductDTO>> GetAllAsync(int pageNumber, int pageSize);
  Task<ProductDTO> GetByID(int id);
  Task<ProductDTO> Create(ProductPostDTO model);
  Task<ProductDTO> Update(ProductDTO modelDTO);
  Task<ProductDTO> Delete(int id);
  bool ProductExists(int id);
}
