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
}
