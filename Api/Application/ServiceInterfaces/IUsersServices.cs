using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Domain.Pagination;

namespace MyAcquisition.Api.Application.ServiceInterfaces;

public interface IUsersServices
{
  Task<PagedList<UserGetDTO>> GetAllAsync(int pageNumber, int pageSize);
  Task<UserGetDTO> GetByID(int id);
  Task<UserDTO> Create(UserDTO model);
  Task<UserDTO> Update(UserDTO modelDTO);
  Task<UserDTO> Delete(int id);
  bool UserExists(int id);
}
