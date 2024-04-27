using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;

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

  [HttpPost]
  public async Task<ActionResult<AcquisitionProductDTO>> CreateAP(AcquisitionProductPostDTO modelDTO)
  {
    var model = await _apServices.Create(modelDTO);
    return CreatedAtAction(nameof(GetProduct), new { id = model.Id }, model);
  }
}
