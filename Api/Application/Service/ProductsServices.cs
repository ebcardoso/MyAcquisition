using AutoMapper;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.Pagination;

namespace MyAcquisition.Api.Application.Service;

public class ProductsServices : IProductsServices
{
  private readonly IProductsRepository _productsRepository;
  private readonly IMapper _mapper;

  public ProductsServices(IProductsRepository productsRepository, IMapper mapper)
  {
    _productsRepository = productsRepository;
    _mapper = mapper;
  }

  public async Task<PagedList<ProductDTO>> GetAllAsync(int pageNumber, int pageSize)
  {
    var models = await _productsRepository.GetAllAsync(pageNumber, pageSize);
    var modelsDTO =  _mapper.Map<IEnumerable<ProductDTO>>(models);
    return new PagedList<ProductDTO>(modelsDTO, pageNumber, pageSize, models.TotalCount);
  }

  public async Task<ProductDTO> GetByID(int id)
  {
    var model = await _productsRepository.GetByID(id);
    return _mapper.Map<ProductDTO>(model);
  }

  public async Task<ProductDTO> Create(ProductPostDTO modelDTO)
  {
    var model = _mapper.Map<Product>(modelDTO);
    var modelCreated = await _productsRepository.Create(model);
    return _mapper.Map<ProductDTO>(modelCreated);
  }

  public async Task<ProductDTO> Update(ProductDTO modelDTO)
  {
    var model = _mapper.Map<Product>(modelDTO);
    var modelChanged = await _productsRepository.Update(model);
    return _mapper.Map<ProductDTO>(modelChanged);
  }

  public async Task<ProductDTO> Delete(int id)
  {
    var modelDeleted = await _productsRepository.Delete(id);
    return _mapper.Map<ProductDTO>(modelDeleted);
  }

  public bool ProductExists(int id)
  {
    return _productsRepository.ProductExists(id);
  }
}
