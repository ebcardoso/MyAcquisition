using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface ICompanyUsersServices
{
  Task<CompanyUserDTO> Create(CompanyUserDTO model);
  Task<CompanyUserDTO> Delete(int id);
  bool CompanyUserExists(int id);
}
