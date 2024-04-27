using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Presentation.Responses.Auth;

namespace MyAcquisition.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AcquisitionProductsController : ControllerBase
{
  private readonly IAcquisitionProductsServices _apServices;

  public AcquisitionProductsController(IAcquisitionProductsServices apServices)
  {
    _apServices = apServices;
  }
}
