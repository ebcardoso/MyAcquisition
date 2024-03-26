using Microsoft.AspNetCore.Mvc;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using MyAcquisition.Api.Presentation.Responses.Auth;
using MyAcquisition.Api.Presentation.Extensions;

namespace MyAcquisition.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BrandsController : ControllerBase
{
  private readonly IBrandsServices _brandsServices;

  public BrandsController(IBrandsServices brandsServices)
  {
    _brandsServices = brandsServices;
  }

  [HttpGet]
  public async Task<IEnumerable<BrandDTO>> GetBrands([FromQuery]PaginationParams paginationParams)
  {
    var modelsDTO = await _brandsServices.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

    Response.AddPaginationHeader(new PaginationHeader(modelsDTO.CurrentPage,
      modelsDTO.PageSize, modelsDTO.TotalCount, modelsDTO.TotalPages));

    return modelsDTO;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<BrandDTO>> GetBrand(int id)
  {
    var modelDTO = await _brandsServices.GetByID(id);
    if (modelDTO == null)
    { 
      var response = new ErrorResponse{ Message = "Brand not found." };
      return NotFound(response);
    }
    return modelDTO;
  }

  [HttpPost]
  public async Task<ActionResult<BrandDTO>> CreateBrand(BrandDTO modelDTO)
  {
    var model = await _brandsServices.Create(modelDTO);
    return model;
  }

  [HttpPut]
  public async Task<ActionResult<BrandDTO>> UpdateBrand(BrandDTO modelDTO)
  {
    if (modelDTO.Id == 0)
    {
      var response = new ErrorResponse{ Message ="Id is necessary to update a brand." };
      return BadRequest(response);
    }

    if(!_brandsServices.BrandExists(modelDTO.Id))
    {
      var response = new ErrorResponse{ Message = "Brand not found." };
      return NotFound(response);
    }

    var model = await _brandsServices.Update(modelDTO);
    return model;
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult<BrandDTO>> DeleteBrand(int id)
  {
    if(!_brandsServices.BrandExists(id))
    {
      var response = new ErrorResponse{ Message = "Brand not found." };
      return NotFound(response);
    }

    var model = await _brandsServices.Delete(id);
    return model;
  }
}
