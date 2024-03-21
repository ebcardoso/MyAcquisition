using AutoMapper;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Presentation.Mapping;

public class ProductsMapping : Profile
{
  public ProductsMapping()
  {
    CreateMap<ProductDTO, Product>().ReverseMap()
      .ForMember(dest => dest.BrandDTO, opt => opt.MapFrom(x => x.Brand));
    CreateMap<Product, ProductPostDTO>().ReverseMap();
  }
}
