using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyAcquisition.Api.Application.DTO;

public class BrandDTO
{
  [IgnoreDataMember]
  public int Id { get; set; }

  [Required(ErrorMessage = "Name is required")]
  [MinLength(5, ErrorMessage = "This field should have at least 5 characters")]
  [StringLength(100)]
  public string? Name { get; set; }

  [Required(ErrorMessage = "LegalName is required")]
  [MinLength(5, ErrorMessage = "This field should have at least 5 characters")]
  [StringLength(100)]
  public string? LegalName { get; set; }

  [Required(ErrorMessage = "TradeName is required")]
  [MinLength(5, ErrorMessage = "This field should have at least 5 characters")]
  [StringLength(100)]
  public string? TradeName { get; set; }

  [Required(ErrorMessage = "Document is required")]
  [MinLength(11, ErrorMessage = "This field should have at least 11 characters")]
  [StringLength(14)]
  public string? Document { get; set; }
}
