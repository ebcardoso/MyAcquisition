using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IAcquisitionProposalsServices
{
  Task<AcquisitionProposalDTO> GetByID(int id);
  Task<AcquisitionProposalDTO> Create(AcquisitionProposalPostDTO model);
}