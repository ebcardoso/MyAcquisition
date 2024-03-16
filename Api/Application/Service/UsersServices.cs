using AutoMapper;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Domain.RepositoryInterfaces;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Domain.Models;
using System.Security.Cryptography;
using System.Text;

namespace MyAcquisition.Api.Application.Service;

public class UsersServices : IUsersServices
{
  private readonly IUsersRepository _usersRepository;
  private readonly IMapper _mapper;

  public UsersServices(IUsersRepository usersRepository, IMapper mapper)
  {
    _usersRepository = usersRepository;
    _mapper = mapper;
  }

  public async Task<IEnumerable<UserDTO>> GetAllAsync()
  {
    var models = await _usersRepository.GetAllAsync();
    return _mapper.Map<IEnumerable<UserDTO>>(models);
  }

  public async Task<UserDTO> GetByID(int id)
  {
    var model = await _usersRepository.GetByID(id);
    return _mapper.Map<UserDTO>(model);
  }

  public async Task<UserDTO> Create(UserDTO modelDTO)
  {
    var model = _mapper.Map<User>(modelDTO);
    if (model != null)
    {
      using var hmac = new HMACSHA512();
      byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(modelDTO.Password));
      byte[] passwordSalt = hmac.Key;
      model.UpdatePassword(passwordHash, passwordSalt);
    }    
    var modelCreated = await _usersRepository.Create(model);
    return _mapper.Map<UserDTO>(modelCreated);
  }
}
