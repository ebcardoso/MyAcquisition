using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcquisition.Api.Application.ServiceInterfaces;

namespace MyAcquisition.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompanyUsersController : ControllerBase
{
  private readonly ICompanyUsersServices _companyUsersServices;

  public CompanyUsersController(ICompanyUsersServices companyUsersServices)
  {
    _companyUsersServices = companyUsersServices;
  }
}
