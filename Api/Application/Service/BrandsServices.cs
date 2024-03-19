using AutoMapper;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Application.Service;

public class BrandsServices : IBrandsServices
{
  private readonly IBrandsRepository _brandsRepository;
  private readonly IMapper _mapper;

  public BrandsServices(IBrandsRepository brandsRepository, IMapper mapper)
  {
    _brandsRepository = brandsRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<BrandDTO>> GetAllAsync()
  {
    var models = await _brandsRepository.GetAllAsync();
    return _mapper.Map<IEnumerable<BrandDTO>>(models);
  }

  public async Task<BrandDTO> GetByID(int id)
  {
    var model = await _brandsRepository.GetByID(id);
    return _mapper.Map<BrandDTO>(model);
  }

  public async Task<BrandDTO> Create(BrandDTO modelDTO)
  {
    var model = _mapper.Map<Brand>(modelDTO);
    var modelCreated = await _brandsRepository.Create(model);
    return _mapper.Map<BrandDTO>(modelCreated);
  }
}
