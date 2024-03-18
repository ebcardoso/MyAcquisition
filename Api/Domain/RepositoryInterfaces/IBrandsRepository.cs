using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Domain.RepositoryInterfaces;

public interface IBrandsRepository
{
  Task<IEnumerable<Brand>> GetAllAsync();
}
