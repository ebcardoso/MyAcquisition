using Microsoft.AspNetCore.Mvc;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using MyAcquisition.Api.Presentation.Responses.Auth;
using MyAcquisition.Api.Infrastructure.Extensions;

namespace MyAcquisition.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
  private readonly IProductsServices _productsServices;

  public ProductsController(IProductsServices productsServices)
  {
    _productsServices = productsServices;
  }

  [HttpGet]
  public async Task<IEnumerable<ProductDTO>> GetProducts()
  {
    var modelsDTO = await _productsServices.GetAllAsync();
    return modelsDTO;
  }

  [HttpPost]
  public async Task<ActionResult<ProductDTO>> CreateProduct(ProductPostDTO modelDTO)
  {
    var model = await _productsServices.Create(modelDTO);
    return model;
  }
}
