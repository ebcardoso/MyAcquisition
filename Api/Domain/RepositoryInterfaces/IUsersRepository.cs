using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IUsersRepository
{
  Task<IEnumerable<User>> GetAllAsync();
  Task<User> GetByID(int id);
  Task<User> GetByEmail(string email);
  Task<User> Create(User model);
}
