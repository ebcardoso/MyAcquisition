using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface ICompanyUsersRepository
{
  Task<CompanyUser> Create(CompanyUser model);
}
