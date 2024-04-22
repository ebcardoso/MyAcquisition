using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Infrastructure.Context;

namespace MyAcquisition.Api.Domain.Repositories;

public class AcquisitionsRepository : IAcquisitionsRepository
{
  private readonly ApiDbContext _context;

  public AcquisitionsRepository(ApiDbContext context)
  {
    _context = context;
  }
}
