using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Presentation.Responses.Auth;

namespace MyAcquisition.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AcquisitionsController : ControllerBase
{
  public readonly IAcquisitionsServices _acquisitionsServices;

  public AcquisitionsController(IAcquisitionsServices acquisitionsServices) {
    _acquisitionsServices = acquisitionsServices;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<AcquisitionDTO>> GetAcquisition(int id)
  {
    var modelDTO = await _acquisitionsServices.GetByID(id);
    if (modelDTO == null)
    {
      var response = new ErrorResponse{ Message = "Acquisition not found." };
      return NotFound(response);
    }
    return modelDTO;
  }

  [HttpPost]
  public async Task<ActionResult<AcquisitionDTO>> CreateAcquisition(AcquisitionPostDTO modelDTO)
  {
    var model = await _acquisitionsServices.Create(modelDTO);
    return CreatedAtAction(nameof(GetAcquisition), new { id = model.Id }, model);
  }
}
