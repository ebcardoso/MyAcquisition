using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface ICompaniesRepository
{
  Task<Company> Create(Company model);
}
