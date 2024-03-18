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
}
