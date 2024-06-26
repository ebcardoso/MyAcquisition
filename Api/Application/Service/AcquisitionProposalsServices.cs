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

  public async Task<AcquisitionProposalDTO> Update(AcquisitionProposalDTO modelDTO)
  {
    var model = _mapper.Map<AcquisitionProposal>(modelDTO);
    var modelChanged = await _apRepository.Update(model);
    return _mapper.Map<AcquisitionProposalDTO>(modelChanged);
  }

  public async Task<AcquisitionProposalDTO> Delete(int id)
  {
    var modelDeleted = await _apRepository.Delete(id);
    return _mapper.Map<AcquisitionProposalDTO>(modelDeleted);
  }

  public bool AcquisitionProposalExists(int id)
  {
    return _apRepository.AcquisitionProposalExists(id);
  }
}
