using System.ComponentModel.DataAnnotations;

namespace MyAcquisition.Api.Application.DTO;

public class AcquisitionProductPutDTO
{
  [Required(ErrorMessage = "Id is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for Id is invalid")]
  public int Id { get; set; }

  [Required(ErrorMessage = "Amount is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for Amount is invalid")]
  public int Amount { get; set; }
}
