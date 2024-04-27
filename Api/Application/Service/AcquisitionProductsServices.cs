using AutoMapper;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.RepositoryInterfaces;

namespace MyAcquisition.Api.Application.Service;

public class AcquisitionProductsServices : IAcquisitionProductsServices
{
  private readonly IAcquisitionProductsRepository _apRepository;
  private readonly IMapper _mapper;

  public AcquisitionProductsServices(IAcquisitionProductsRepository apRepository, IMapper mapper)
  {
    _apRepository = apRepository;
    _mapper = mapper;
  }

  public async Task<AcquisitionProductDTO> GetByID(int id)
  {
    var model = await _apRepository.GetByID(id);
    return _mapper.Map<AcquisitionProductDTO>(model);
  }

  public async Task<AcquisitionProductDTO> Create(AcquisitionProductPostDTO modelDTO)
  {
    var model = _mapper.Map<AcquisitionProduct>(modelDTO);
    var modelCreated = await _apRepository.Create(model);
    return _mapper.Map<AcquisitionProductDTO>(modelCreated);
  }
}
