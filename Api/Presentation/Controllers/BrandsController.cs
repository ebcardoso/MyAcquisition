using Microsoft.AspNetCore.Mvc;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

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
  public async Task<IEnumerable<BrandDTO>> GetBrands()
  {
    var modelsDTO = await _brandsServices.GetAllAsync();
    return modelsDTO;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<BrandDTO>> GetBrand(int id)
  {
    var modelDTO = await _brandsServices.GetByID(id);
    if (modelDTO == null)
    { 
      return NotFound("Brand not found");
    }
    return modelDTO;
  }

  [HttpPost]
  public async Task<ActionResult<BrandDTO>> CreateBrand(BrandDTO modelDTO)
  {
    var model = await _brandsServices.Create(modelDTO);
    return model;
  }
}
