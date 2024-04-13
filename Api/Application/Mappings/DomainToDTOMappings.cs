using AutoMapper;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.Mapping;

public class DomainToDTOMapping : Profile
{
  public DomainToDTOMapping()
  {
    CreateMap<Brand, BrandDTO>().ReverseMap();
    CreateMap<Company, CompanyDTO>().ReverseMap();
    CreateMap<ProductDTO, Product>().ReverseMap()
      .ForMember(dest => dest.BrandDTO, opt => opt.MapFrom(x => x.Brand));
    CreateMap<Product, ProductPostDTO>().ReverseMap();
    CreateMap<User, UserDTO>().ReverseMap();
    CreateMap<User, UserGetDTO>().ReverseMap();
  }
}
