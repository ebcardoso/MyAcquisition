using AutoMapper;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.RepositoryInterfaces;

namespace MyAcquisition.Api.Application.Service;

public class CompanyUsersServices : ICompanyUsersServices
{
  private readonly ICompanyUsersRepository _companyUsersRepository;
  private readonly IMapper _mapper;

  public CompanyUsersServices(ICompanyUsersRepository companyUsersRepository, IMapper mapper)
  {
    _companyUsersRepository = companyUsersRepository;
    _mapper = mapper;
  }

  public async Task<CompanyUserDTO> Create(CompanyUserDTO modelDTO)
  {
    var model = _mapper.Map<CompanyUser>(modelDTO);
    var modelCreated = await _companyUsersRepository.Create(model);
    return _mapper.Map<CompanyUserDTO>(modelCreated);
  }
}
