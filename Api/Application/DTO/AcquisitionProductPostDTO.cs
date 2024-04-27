using System.ComponentModel.DataAnnotations;

namespace MyAcquisition.Api.Application.DTO;

public class AcquisitionProductPostDTO
{
  [Required(ErrorMessage = "AcquisitionId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for AcquisitionId is invalid")]
  public int AcquisitionId { get; set; }

  [Required(ErrorMessage = "ProductId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for ProductId is invalid")]
  public int ProductId { get; set; }

  [Required(ErrorMessage = "Amount is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for Amount is invalid")]
  public int Amount { get; set; }
}
