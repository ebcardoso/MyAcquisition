using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.Pagination;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface ICompaniesRepository
{
  Task<PagedList<Company>> GetAllAsync(int pageNumber, int pageSize);
  Task<Company> GetByID(int id);
  Task<Company> Create(Company model);
}
