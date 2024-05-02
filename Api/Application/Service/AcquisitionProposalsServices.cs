using AutoMapper;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.RepositoryInterfaces;

namespace MyAcquisition.Api.Application.Service;

public class AcquisitionProposalsServices : IAcquisitionProposalsServices
{
  private readonly IAcquisitionProposalsRepository _apRepository;
  private readonly IMapper _mapper;

  public AcquisitionProposalsServices(IAcquisitionProposalsRepository apRepository, IMapper mapper)
  {
    _apRepository = apRepository;
    _mapper = mapper;
  }

  public async Task<AcquisitionProposalDTO> GetByID(int id)
  {
    var model = await _apRepository.GetByID(id);
    return _mapper.Map<AcquisitionProposalDTO>(model);
  }

  public async Task<AcquisitionProposalDTO> Create(AcquisitionProposalPostDTO modelDTO)
  {
    var model = _mapper.Map<AcquisitionProposal>(modelDTO);
    var modelCreated = await _apRepository.Create(model);
    return _mapper.Map<AcquisitionProposalDTO>(modelCreated);
  }
}
