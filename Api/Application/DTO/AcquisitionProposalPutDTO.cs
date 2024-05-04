using System.ComponentModel.DataAnnotations;

namespace MyAcquisition.Api.Application.DTO;

public class AcquisitionProposalPutDTO
{
  [Required(ErrorMessage = "Id is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for Id is invalid")]
  public int Id { get; set; }

  [Required(ErrorMessage = "Price is required")]
  [Range(0.1, int.MaxValue, ErrorMessage = "The value for Price is invalid")]
  public decimal Price { get; set; }
}
