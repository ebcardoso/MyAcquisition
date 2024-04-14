using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Domain.Pagination;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface ICompaniesServices
{
  Task<PagedList<CompanyDTO>> GetAllAsync(int pageNumber, int pageSize);
  Task<CompanyDTO> GetByID(int id);
  Task<CompanyDTO> Create(CompanyDTO model);
}
