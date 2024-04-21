using System.ComponentModel.DataAnnotations;

namespace MyAcquisition.Api.Application.DTO;

public class AcquisitionPostDTO
{
  [Required(ErrorMessage = "CompanyId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for CompanyId is invalid")]
  public int CompanyId { get; set; }

  [Required(ErrorMessage = "Deadline is required")]
  public string? Deadline { get; set; }
}
