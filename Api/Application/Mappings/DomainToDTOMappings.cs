using AutoMapper;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.Mapping;

public class DomainToDTOMapping : Profile
{
  public DomainToDTOMapping()
  {
    CreateMap<AcquisitionDTO, Acquisition>().ReverseMap()
      .ForMember(dest => dest.CompanyDTO, opt => opt.MapFrom(x => x.Company));
    CreateMap<Acquisition, AcquisitionPostDTO>().ReverseMap();
    CreateMap<Brand, BrandDTO>().ReverseMap();
    CreateMap<Company, CompanyDTO>().ReverseMap();
    CreateMap<CompanyUserDTO, CompanyUser>().ReverseMap()
      .ForMember(dest => dest.CompanyDTO, opt => opt.MapFrom(x => x.Company))
      .ForMember(dest => dest.UserGetDTO, opt => opt.MapFrom(x => x.User));
    CreateMap<ProductDTO, Product>().ReverseMap()
      .ForMember(dest => dest.BrandDTO, opt => opt.MapFrom(x => x.Brand))
      .ForMember(dest => dest.CompanyDTO, opt => opt.MapFrom(x => x.Company));
    CreateMap<Product, ProductPostDTO>().ReverseMap();
    CreateMap<User, UserDTO>().ReverseMap();
    CreateMap<User, UserGetDTO>().ReverseMap();
  }
}
