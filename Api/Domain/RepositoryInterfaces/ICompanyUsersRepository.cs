using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface ICompanyUsersRepository
{
  Task<CompanyUser> GetByID(int id);
  Task<CompanyUser> Create(CompanyUser model);
  Task<CompanyUser> Delete(int id);
  bool CompanyUserExists(int id);
}
