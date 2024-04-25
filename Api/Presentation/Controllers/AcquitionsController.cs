using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using MyAcquisition.Api.Infrastructure.Extensions;
using MyAcquisition.Api.Presentation.Models;
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

  [HttpGet]
  public async Task<IEnumerable<AcquisitionDTO>> GetAcquisitions([FromQuery]PaginationParams paginationParams)
  {
    var modelsDTO = await _acquisitionsServices.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

    Response.AddPaginationHeader(new PaginationHeader(modelsDTO.CurrentPage,
      modelsDTO.PageSize, modelsDTO.TotalCount, modelsDTO.TotalPages));

    return modelsDTO;
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

  [HttpPut]
  public async Task<ActionResult<AcquisitionDTO>> UpdateAcquisition(AcquisitionPutDTO modelPutDTO)
  {
    var modelDTO = await _acquisitionsServices.GetByID(modelPutDTO.Id);
    if(modelDTO == null)
    {
      var response = new ErrorResponse{ Message = "Acquisition not found." };
      return NotFound(response);
    }

    modelDTO.Deadline = DateOnly.Parse(modelPutDTO.Deadline);

    var model = await _acquisitionsServices.Update(modelDTO);
    if (model == null)
    {
      var response = new ErrorResponse{ Message = "Error to update Acquisition." };
      return BadRequest(response);
    }
    return model;
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult<AcquisitionDTO>> DeleteBrand(int id)
  {
    if(!_acquisitionsServices.AcquisitionExists(id))
    {
      var response = new ErrorResponse{ Message = "Acquisition not found." };
      return NotFound(response);
    }

    var model = await _acquisitionsServices.Delete(id);
    return model;
  }
}
