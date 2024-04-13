using System.ComponentModel.DataAnnotations;

namespace MyAcquisition.Api.Application.DTO;

public class CompanyDTO
{
  public int Id { get; set; }
  
  [Required(ErrorMessage = "LegalName is required", AllowEmptyStrings=false)]
  [StringLength(100, ErrorMessage = "LegalName cannot be longer than 100 characters")]
  public string LegalName { get; set; }
  
  [Required(ErrorMessage = "TradeName is required", AllowEmptyStrings=false)]
  [StringLength(100, ErrorMessage = "TradeName cannot be longer than 100 characters")]
  public string TradeName { get; set; }
  
  [Required(ErrorMessage = "Document is required", AllowEmptyStrings=false)]
  [StringLength(14, ErrorMessage = "Document cannot be longer than 14 characters")]
  public string Document { get; set; }
  
  [Required(ErrorMessage = "Phone is required", AllowEmptyStrings=false)]
  [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters")]
  public string Phone { get; set; }
  
  [Required(ErrorMessage = "Email is required", AllowEmptyStrings=false)]
  [StringLength(70, ErrorMessage = "Email cannot be longer than 70 characters")]
  [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email format is invalid")]
  public string Email { get; set; }
  
  [Required(ErrorMessage = "ZipCode is required", AllowEmptyStrings=false)]
  [StringLength(8, ErrorMessage = "ZipCode cannot be longer than 8 characters")]
  public string ZipCode { get; set; }
  
  [Required(ErrorMessage = "StreetName is required", AllowEmptyStrings=false)]
  [StringLength(100, ErrorMessage = "StreetName cannot be longer than 100 characters")]
  public string StreetName { get; set; }
  
  [Required(ErrorMessage = "StreetNumber is required", AllowEmptyStrings=false)]
  [StringLength(7, ErrorMessage = "StreetNumber cannot be longer than 7 characters")]
  public string StreetNumber { get; set; }
  
  [Required(ErrorMessage = "Neighborhood is required", AllowEmptyStrings=false)]
  [StringLength(50, ErrorMessage = "Neighborhood cannot be longer than 50 characters")]
  public string Neighborhood { get; set; }

  [Required(ErrorMessage = "Complement is required", AllowEmptyStrings=true)]
  [StringLength(100, ErrorMessage = "Complement cannot be longer than 100 characters")]
  public string Complement { get; set; }
  
  [Required(ErrorMessage = "City is required", AllowEmptyStrings=false)]
  [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters")]
  public string City { get; set; }
  
  [Required(ErrorMessage = "State is required")]
  [StringLength(2, MinimumLength = 2, ErrorMessage = "State must be 2 characters")]
  public string State { get; set; }
}
