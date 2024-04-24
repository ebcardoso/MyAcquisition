using System.ComponentModel.DataAnnotations;
using MyAcquisition.Api.Domain.Enums;

namespace MyAcquisition.Api.Application.DTO;

public class AcquisitionPutDTO
{
  [Required(ErrorMessage = "Id is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for Id is invalid")]
  public int Id { get; set; }

  [Required(ErrorMessage = "Deadline is required")]
  public string? Deadline { get; set; }
}
