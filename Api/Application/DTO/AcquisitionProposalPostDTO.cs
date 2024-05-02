using System.ComponentModel.DataAnnotations;

namespace MyAcquisition.Api.Application.DTO;

public class AcquisitionProposalPostDTO
{
  [Required(ErrorMessage = "AcquisitionProductId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for AcquisitionProductId is invalid")]
  public int AcquisitionProductId { get; set; }

  [Required(ErrorMessage = "UserId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for UserId is invalid")]
  public int UserId { get; set; }

  [Required(ErrorMessage = "Price is required")]
  [Range(0.1, int.MaxValue, ErrorMessage = "The value for Price is invalid")]
  public decimal Price { get; set; }
}
