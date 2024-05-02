using System.ComponentModel.DataAnnotations;
using MyAcquisition.Api.Domain.Models;

namespace MyAcquisition.Api.Application.DTO;

public class AcquisitionProposalDTO
{
  [Required(ErrorMessage = "Id is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for Id is invalid")]
  public int Id { get; set; }

  [Required(ErrorMessage = "AcquisitionProductId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for AcquisitionProductId is invalid")]
  public int AcquisitionProductId { get; set; }

  [Required(ErrorMessage = "UserId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for UserId is invalid")]
  public int UserId { get; set; }

  [Required(ErrorMessage = "Price is required")]
  [Range(0.1, int.MaxValue, ErrorMessage = "The value for Price is invalid")]
  public decimal Price { get; set; }

  public AcquisitionProductDTO AcquisitionProductDTO { get; set; }
  
  public UserGetDTO UserGetDTO { get; set; }
}
