using System.ComponentModel.DataAnnotations;
using MyAcquisition.Api.Domain.Enums;

namespace MyAcquisition.Api.Application.DTO;

public class ProductDTO
{
  public int Id { get; set; }

  [Required(ErrorMessage = "BrandId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "Thee value of BrandId is invalid")]
  public int BrandId { get; set; }

  [Required(ErrorMessage = "Name is required")]
  [MinLength(1, ErrorMessage = "This field should have at least 1 characters")]
  public string? Name { get; set; }

  [Required(ErrorMessage = "Unit is required")]
  public Units? Unit { get; set; }
  
  [Required(ErrorMessage = "Quantity is required")]
  [MinLength(1, ErrorMessage = "This field should have at least 1 characters")]
  [StringLength(100)]
  public string? Quantity { get; set; }

  public BrandDTO BrandDTO { get; set; }
}
