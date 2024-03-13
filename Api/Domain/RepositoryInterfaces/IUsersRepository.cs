using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IUsersRepository
{
  Task<User> GetByEmail(string email);
  Task<User> Create(User model);
}
