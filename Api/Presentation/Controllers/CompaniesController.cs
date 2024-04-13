
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcquisition.Api.Application.DTO;
using MyAcquisition.Api.Application.ServiceInterfaces;

namespace MyAcquisition.Api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CompaniesController : ControllerBase
{
  private readonly ICompaniesServices _companiesServices;

  public CompaniesController(ICompaniesServices companiessServices)
  {
    _companiesServices = companiessServices;
  }

  [HttpPost]
  public async Task<ActionResult<CompanyDTO>> CreateCompany(CompanyDTO modelDTO)
  {
    var model = await _companiesServices.Create(modelDTO);
    return model;
  }
}
