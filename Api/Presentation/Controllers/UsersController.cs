using Microsoft.AspNetCore.Mvc;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;

namespace MyAcquisition.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly IUsersServices _usersServices;

  public UsersController(IUsersServices usersServices)
  {
    _usersServices = usersServices;
  }

  [HttpGet]
  public async Task<IEnumerable<UserDTO>> GetUsers()
  {
    var modelsDTO = await _usersServices.GetAllAsync();
    return modelsDTO;
  }  
}
