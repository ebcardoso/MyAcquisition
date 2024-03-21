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

  public async Task<ProductDTO> Create(ProductPostDTO modelDTO)
  {
    var model = _mapper.Map<Product>(modelDTO);
    var modelCreated = await _productsRepository.Create(model);
    return _mapper.Map<ProductDTO>(modelCreated);
  }
}
