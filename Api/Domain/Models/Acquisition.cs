using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyAcquisition.Api.Infrastructure.Exceptions;

namespace  MyAcquisition.Api.Domain.Models;

[Table("Acquisition")]
public class Acquisition : BaseModel
{
  [Column("id")]
  public int Id { get; private set; }

  [Column("company_id")]
  public int CompanyId { get; private set; }

  [Required]
  [Column("deadline")]
  public DateOnly Deadline { get; set; }

  public Company Company { get; set; }

  public Acquisition(int id, int companyId, DateOnly deadline)
  {
    ModelValidationException.When(id < 0, "Field Id should to be greater than 0");
    Id = id;

    ValidateModel(companyId, deadline.ToString());
  }

  public Acquisition(int id, int companyId, string deadline)
  {
    ModelValidationException.When(id < 0, "Field Id should to be greater than 0");
    Id = id;

    ValidateModel(companyId, deadline);
  }

  public Acquisition(int companyId, string deadline)
  {
    ValidateModel(companyId, deadline);
  }

  private void ValidateModel(int companyId, string deadline)
  {
    ModelValidationException.When(companyId < 0, "Field CompanyId should to be greater than 0");
    ModelValidationException.When(deadline == null, "Field Deadline is required");

    CompanyId = companyId;
    Deadline = DateOnly.Parse(deadline);
  }
}
