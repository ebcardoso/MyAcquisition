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

  [HttpGet("{id}")]
  public async Task<ActionResult<AcquisitionProductDTO>> GetAP(int id)
  {
    var modelDTO = await _apServices.GetByID(id);
    if (modelDTO == null)
    {
      var response = new ErrorResponse{ Message = "Relashionship betweet Acquisition-Product not found." };
      return NotFound(response);
    }
    return modelDTO;
  }

  [HttpPost]
  public async Task<ActionResult<AcquisitionProductDTO>> CreateAP(AcquisitionProductPostDTO modelDTO)
  {
    var model = await _apServices.Create(modelDTO);
    return CreatedAtAction(nameof(GetAP), new { id = model.Id }, model);
  }
}
