using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyAcquisition.Api.Application.DTO;

public class CompanyUserDTO
{
  public int Id { get; set; }

  [Required(ErrorMessage = "CompanyId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for CompanyId is invalid")]
  public int CompanyId { get; set; }

  [Required(ErrorMessage = "UserId is required")]
  [Range(1, int.MaxValue, ErrorMessage = "The value for UserId is invalid")]
  public int UserId { get; set; }

  [Required(ErrorMessage = "IsAdmin is required")]
  public bool IsAdmin { get; set; }

  [JsonPropertyName("company")]
  public CompanyDTO CompanyDTO { get; set; }

  [JsonPropertyName("user")]
  public UserGetDTO UserGetDTO { get; set; }
}
