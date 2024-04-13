using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface ICompaniesServices
{
  Task<CompanyDTO> Create(CompanyDTO model);
}
