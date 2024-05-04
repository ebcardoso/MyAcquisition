using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Presentation.Responses.Auth;

namespace MyAcquisition.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AcquisitionProposalsController : ControllerBase
{
  private readonly IAcquisitionProposalsServices _apServices;

  public AcquisitionProposalsController(IAcquisitionProposalsServices apServices)
  {
    _apServices = apServices;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<AcquisitionProposalDTO>> GetAP(int id)
  {
    var modelDTO = await _apServices.GetByID(id);
    if (modelDTO == null)
    {
      var response = new ErrorResponse{ Message = "Acquisition-Proposal not found." };
      return NotFound(response);
    }
    return modelDTO;
  }

  [HttpPost]
  public async Task<ActionResult<AcquisitionProposalDTO>> CreateAP(AcquisitionProposalPostDTO modelDTO)
  {
    var model = await _apServices.Create(modelDTO);
    return CreatedAtAction(nameof(GetAP), new { id = model.Id }, model);
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult<AcquisitionProposalDTO>> DeleteAP(int id)
  {
    if(!_apServices.AcquisitionProposalExists(id))
    {
      var response = new ErrorResponse{ Message = "Acquisition-Proposal not found." };
      return NotFound(response);
    }

    var model = await _apServices.Delete(id);
    return model;
  }
}
