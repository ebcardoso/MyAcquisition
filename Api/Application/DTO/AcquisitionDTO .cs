using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyAcquisition.Api.Application.DTO;

public class AcquisitionDTO
{
  public int Id { get; set; }

  [Required(ErrorMessage = "CompanyId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for CompanyId is invalid")]
  public int CompanyId { get; set; }

  [Required(ErrorMessage = "Deadline is required")]
  public DateOnly? Deadline { get; set; }

  [JsonPropertyName("company")]
  public CompanyDTO CompanyDTO { get; set; }
}
