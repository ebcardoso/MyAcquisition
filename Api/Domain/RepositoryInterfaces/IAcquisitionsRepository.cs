using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IAcquisitionsRepository
{
  Task<Acquisition> GetByID(int id);
}
