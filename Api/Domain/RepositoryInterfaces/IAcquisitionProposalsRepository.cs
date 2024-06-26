using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IAcquisitionProposalsRepository
{
  Task<AcquisitionProposal> GetByID(int id);
  Task<AcquisitionProposal> Create(AcquisitionProposal model);
  Task<AcquisitionProposal> Update(AcquisitionProposal model);
  Task<AcquisitionProposal> Delete(int id);
  bool AcquisitionProposalExists(int id);
}
