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

  [HttpPost]
  public async Task<ActionResult<AcquisitionProposalDTO>> CreateProduct(AcquisitionProposalPostDTO modelDTO)
  {
    var model = await _apServices.Create(modelDTO);
    return CreatedAtAction(nameof(GetAP), new { id = model.Id }, model);
  }
}
