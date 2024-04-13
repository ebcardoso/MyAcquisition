using AutoMapper;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.Pagination;
using MyAcquisition.Api.Domain.RepositoryInterfaces;

namespace MyAcquisition.Api.Application.Service;

public class CompaniesServices : ICompaniesServices
{
  private readonly ICompaniesRepository _companiesRepository;
  private readonly IMapper _mapper;

  public CompaniesServices(ICompaniesRepository companiesRepository, IMapper mapper)
  {
    _companiesRepository = companiesRepository;
    _mapper = mapper;
  }

  public async Task<PagedList<CompanyDTO>> GetAllAsync(int pageNumber, int pageSize)
  {
    var models = await _companiesRepository.GetAllAsync(pageNumber, pageSize);
    var modelsDTO =  _mapper.Map<IEnumerable<CompanyDTO>>(models);
    return new PagedList<CompanyDTO>(modelsDTO, pageNumber, pageSize, models.TotalCount);
  }

  public async Task<CompanyDTO> Create(CompanyDTO modelDTO)
  {
    var model = _mapper.Map<Company>(modelDTO);
    var modelCreated = await _companiesRepository.Create(model);
    return _mapper.Map<CompanyDTO>(modelCreated);
  }
}
