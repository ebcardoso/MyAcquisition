using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyAcquisition.Api.Infrastructure.Exceptions;

namespace MyAcquisition.Api.Domain.Models;

public class CompanyUser
{
  [Column("id")]
  public int Id { get; set; }

  [Column("company_id")]
  public int CompanyId { get; private set; }

  [Column("user_id")]
  public int UserId { get; private set; }

  [Required]
  [Column("is_admin")]
  public bool IsAdmin { get; set; }

  public Company Company { get; set; }

  public User User { get; set; }

  public CompanyUser(int id, int companyId, int userId)
  {
    ModelValidationException.When(id < 0, "Field Id should to be greater than 0");
    Id = id;

    ValidateModel(companyId, userId);
  }

  public CompanyUser(int companyId, int userId)
  {
    ValidateModel(companyId, userId);
  }

  private void ValidateModel(int companyId, int userId)
  {
    ModelValidationException.When(companyId < 0, "Field CompanyId should to be greater than 0");
    ModelValidationException.When(userId < 0, "Field UserId should to be greater than 0");

    CompanyId = companyId;
    UserId = userId;
    IsAdmin = false;
  }
}
