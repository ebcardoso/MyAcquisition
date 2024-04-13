using AutoMapper;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.Mapping;

public class DomainToDTOMapping : Profile
{
  public DomainToDTOMapping()
  {
    CreateMap<Company, CompanyDTO>().ReverseMap();
  }
}
