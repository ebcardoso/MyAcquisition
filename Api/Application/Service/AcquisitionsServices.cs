using AutoMapper;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.RepositoryInterfaces;

namespace MyAcquisition.Api.Application.Service;

public class AcquisitionsServices : IAcquisitionsServices
{
  private readonly IAcquisitionsRepository _acquisitionsRepository;
  private readonly IMapper _mapper;

  public AcquisitionsServices(IAcquisitionsRepository acquisitionsRepository, IMapper mapper)
  {
    _acquisitionsRepository = acquisitionsRepository;
    _mapper = mapper;
  }

  public async Task<AcquisitionDTO> GetByID(int id)
  {
    var model = await _acquisitionsRepository.GetByID(id);
    return _mapper.Map<AcquisitionDTO>(model);
  }

  public async Task<AcquisitionDTO> Create(AcquisitionPostDTO modelDTO)
  {
    var model = _mapper.Map<Acquisition>(modelDTO);
    var modelCreated = await _acquisitionsRepository.Create(model);
    return _mapper.Map<AcquisitionDTO>(modelCreated);
  }

  public async Task<AcquisitionDTO> Update(AcquisitionDTO modelDTO)
  {
    var model = _mapper.Map<Acquisition>(modelDTO);
    var modelChanged = await _acquisitionsRepository.Update(model);
    return _mapper.Map<AcquisitionDTO>(modelChanged);
  }

  public async Task<AcquisitionDTO> Delete(int id)
  {
    var modelDeleted = await _acquisitionsRepository.Delete(id);
    return _mapper.Map<AcquisitionDTO>(modelDeleted);
  }

  public bool AcquisitionExists(int id)
  {
    return _acquisitionsRepository.AcquisitionExists(id);
  }
}
