using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IUsersServices
{
  Task<UserDTO> Create(UserDTO model);
}
