using AutoMapper;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Presentation.Mapping;

public class UsersMapping : Profile
{
  public UsersMapping()
  {
    CreateMap<User, UserDTO>().ReverseMap();
  }
}
