using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Domain.RepositoryInterfaces;

namespace MyAcquisition.Api.Application.Service;

public class AuthServices : IAuthServices
{
  private readonly IUsersRepository _usersRepository;
  private readonly IMapper _mapper;
  private readonly IConfiguration _configuration;

  public AuthServices(IUsersRepository usersRepository, IMapper mapper, IConfiguration configuration)
  {
    _usersRepository = usersRepository;
    _mapper = mapper;
    _configuration = configuration;
  }
  
  public async Task<bool> UserExists(string email)
  {
    var user = await _usersRepository.GetByEmail(email);
    if (user == null)
    {
      return false;
    }
    return true;
  }

  public string GenerateToken(int id, string email)
  {
    var claims = new[]
    {
      new Claim("id", id.ToString()),
      new Claim("email", email),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));
    var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
    var expiration = DateTime.UtcNow.AddMinutes(10);
    JwtSecurityToken token = new JwtSecurityToken(
      issuer: _configuration["jwt:issuer"],
      audience: _configuration["jwt:audience"],
      claims: claims,
      expires: expiration,
      signingCredentials: credentials
    );
    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
