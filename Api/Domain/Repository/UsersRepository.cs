using Microsoft.EntityFrameworkCore;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Domain.Models;
using MyAcquisition.Api.Infrastructure.Context;

namespace MyAcquisition.Api.Domain.Repositories;

public class UsersRepository : IUsersRepository
{
  private readonly ApiDbContext _context;

  public UsersRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<User>> GetAllAsync()
  {
    return await _context.Users.ToListAsync();
  }

  public async Task<User> GetByID(int id)
  {
    var model = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
    return model;
  }

  public async Task<User> GetByEmail(string email)
  {
    var model = await _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
    return model;
  }

  public async Task<User> Create(User model)
  {
    _context.Users.Add(model);
    await _context.SaveChangesAsync();
    return model;
  }

  public async Task<User> Update(User model)
  {
    _context.Entry(model).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return model;
  }

  public async Task<User> Delete(int id)
  {
    var model = await GetByID(id);
    if (model != null)
    {
      _context.Users.Remove(model);
      await _context.SaveChangesAsync();
      return model;
    }
    return null;
  }

  public bool UserExists(int id)
  {
    return _context.Users.Any(e => e.Id == id);
  }
}
