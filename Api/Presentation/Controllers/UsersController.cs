using Microsoft.AspNetCore.Mvc;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Presentation.Responses.Auth;

namespace MyAcquisition.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly IUsersServices _usersServices;
  private readonly IAuthServices _authServices;

  public UsersController(IUsersServices usersServices, IAuthServices authServices)
  {
    _usersServices = usersServices;
    _authServices = authServices;
  }

  [HttpGet]
  public async Task<IEnumerable<UserDTO>> GetUsers()
  {
    var modelsDTO = await _usersServices.GetAllAsync();
    return modelsDTO;
  }

  [HttpPost]
  public async Task<ActionResult<UserDTO>> CreateUser(UserDTO modelDTO)
  {
    var emailExists = await _authServices.UserExists(modelDTO.Email);
    if (emailExists)
    {
      var response = new ErrorResponse{ Message = "This email already exists."};
      return BadRequest(response);
    }

    var model = await _usersServices.Create(modelDTO);
    return model;
  }
}
