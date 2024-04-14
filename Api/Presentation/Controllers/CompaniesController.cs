
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
public class CompaniesController : ControllerBase
{
  private readonly ICompaniesServices _companiesServices;

  public CompaniesController(ICompaniesServices companiessServices)
  {
    _companiesServices = companiessServices;
  }

  [HttpGet]
  public async Task<IEnumerable<CompanyDTO>> GetCompanies([FromQuery]PaginationParams paginationParams)
  {
    var modelsDTO = await _companiesServices.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

    Response.AddPaginationHeader(new PaginationHeader(modelsDTO.CurrentPage,
      modelsDTO.PageSize, modelsDTO.TotalCount, modelsDTO.TotalPages));

    return modelsDTO;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
  {
    var modelDTO = await _companiesServices.GetByID(id);
    if (modelDTO == null)
    {
      var response = new ErrorResponse{ Message = "Company not found." };
      return NotFound(response);
    }
    return modelDTO;
  }

  [HttpPost]
  public async Task<ActionResult<CompanyDTO>> CreateCompany(CompanyDTO modelDTO)
  {
    var model = await _companiesServices.Create(modelDTO);
    return model;
  }
}
