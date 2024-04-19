using System.ComponentModel.DataAnnotations;

namespace MyAcquisition.Api.Application.DTO;

public class CompanyUserPostDTO
{
  [Required(ErrorMessage = "CompanyId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for CompanyId is invalid")]
  public int CompanyId { get; set; }

  [Required(ErrorMessage = "Email is required")]
  [MinLength(5, ErrorMessage = "This field should have at least 5 characters")]
  [StringLength(100)]
  public string? Email { get; set; }
}
