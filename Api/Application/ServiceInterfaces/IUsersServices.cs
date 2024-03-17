using MyAcquisition.Api.Application.DTO;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IUsersServices
{
  Task<IEnumerable<UserDTO>> GetAllAsync();
  Task<UserDTO> GetByID(int id);
  Task<UserDTO> Create(UserDTO model);
  Task<UserDTO> Delete(int id);
  bool UserExists(int id);
}
