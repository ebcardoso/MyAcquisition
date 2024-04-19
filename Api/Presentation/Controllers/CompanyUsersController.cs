using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Presentation.Responses.Auth;

namespace MyAcquisition.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompanyUsersController : ControllerBase
{
  private readonly ICompanyUsersServices _companyUsersServices;
  private readonly ICompaniesServices _companiesServices;
  private readonly IUsersServices _usersServices;

  public CompanyUsersController(ICompanyUsersServices companyUsersServices,
                                ICompaniesServices companiesServices,
                                IUsersServices usersServices)
  {
    _companyUsersServices = companyUsersServices;
    _companiesServices = companiesServices;
    _usersServices = usersServices;
  }

  [HttpPost]
  public async Task<ActionResult<CompanyUserDTO>> CreateCompanyUser(CompanyUserPostDTO modelDTO)
  {
    var companyDTO = await _companiesServices.GetByID(modelDTO.CompanyId);
    if (companyDTO == null)
    {
      var response = new ErrorResponse{ Message = "Company not found" };
      return NotFound(response);
    }

    var userDTO = await _usersServices.GetByEmail(modelDTO.Email);
    if (userDTO == null)
    {
      var response = new ErrorResponse{ Message = "User not found"};
      return NotFound(response);
    }

    var modelInsert = new CompanyUserDTO {
      CompanyId = companyDTO.Id,
      UserId = userDTO.Id
    };

    var model = await _companyUsersServices.Create(modelInsert);
    return model;
  }
}
