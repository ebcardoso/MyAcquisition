using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IAcquisitionProposalsRepository
{
  Task<AcquisitionProposal> Create(AcquisitionProposal model);
}
