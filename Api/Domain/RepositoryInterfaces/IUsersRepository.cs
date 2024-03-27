using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.Pagination;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IUsersRepository
{
  Task<PagedList<User>> GetAllAsync(int pageNumber, int pageSize);
  Task<User> GetByID(int id);
  Task<User> GetByEmail(string email);
  Task<User> Create(User model);
  Task<User> Update(User model);
  Task<User> Delete(int id);
  bool UserExists(int id);
}
