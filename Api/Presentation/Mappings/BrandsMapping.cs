using AutoMapper;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Presentation.Mapping;

public class BrandsMapping : Profile
{
  public BrandsMapping()
  {
    CreateMap<Brand, BrandDTO>().ReverseMap();
  }
}
