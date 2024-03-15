using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IUsersServices
{
  Task<IEnumerable<UserDTO>> GetAllAsync();
  Task<UserDTO> Create(UserDTO model);
}
