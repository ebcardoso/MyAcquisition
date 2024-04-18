using System.ComponentModel.DataAnnotations;

namespace MyAcquisition.Api.Application.DTO;

public class CompanyUserPostDTO
{
  [Required(ErrorMessage = "CompanyId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for CompanyId is invalid")]
  public int CompanyId { get; set; }

  [Required(ErrorMessage = "UserId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for UserId is invalid")]
  public int UserId { get; set; }
}
