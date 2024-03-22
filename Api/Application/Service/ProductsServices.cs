using AutoMapper;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Domain.Models;

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

  public async Task<IEnumerable<ProductDTO>> GetAllAsync()
  {
    var models = await _productsRepository.GetAllAsync();
    return _mapper.Map<IEnumerable<ProductDTO>>(models);
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
