using AutoMapper;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.RepositoryInterfaces;

namespace MyAcquisition.Api.Application.Service;

public class AcquisitionProductsServices : IAcquisitionProductsServices
{
  private readonly IAcquisitionProductsRepository _apRepository;
  private readonly IMapper _mapper;

  public AcquisitionProductsServices(IAcquisitionProductsRepository apRepository, IMapper mapper)
  {
    _apRepository = apRepository;
    _mapper = mapper;
  }
}
