// using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyAcquisition.Api.Infrastructure.Exceptions;

namespace MyAcquisition.Api.Domain.Models;

[Table("brands")]
public class Brand : BaseModel
{
  [Column("id")]
  public int Id { get; set; }

  [Required]
  [Column("name")]
  [StringLength(100)]
  public string Name { get; set; }

  [Required]
  [Column("legal_name")]
  [StringLength(100)]
  public string LegalName { get; set; }

  [Required]
  [Column("trade_name")]
  [StringLength(100)]
  public string TradeName { get; set; }

  [Required]
  [Column("document")]
  [StringLength(14)]
  public string Document { get; set; }

  public Brand(int id, string name, string legalName, string tradeName, string document)
  {
    ModelValidationException.When(id < 0, "Field Id should to be greater than 0");
    Id = id;

    ValidateModel(name, legalName, tradeName, document);
  }

  public Brand(string name, string legalName, string tradeName, string document)
  {
    ValidateModel(name, legalName, tradeName, document);
  }

  public void Update(string name, string legalName, string tradeName, string document)
  {
    ValidateModel(name, legalName, tradeName, document);
  }

  private void ValidateModel(string name, string legalName, string tradeName, string document)
  {
    ModelValidationException.When(name == null, "Field Name is required");
    ModelValidationException.When(legalName == null, "Field LegalName is required");
    ModelValidationException.When(tradeName == null, "Field TradeName is required");
    ModelValidationException.When(document == null, "Field Document is required");

    ModelValidationException.When(name.Length > 100, "Maximum size for Name is 100 characters");
    ModelValidationException.When(legalName.Length > 100, "Maximum size for LegalName is 100 characters");
    ModelValidationException.When(tradeName.Length > 100, "Maximum size for TradeName is 100 characters");
    ModelValidationException.When(document.Length > 14, "Maximum size for Document is 100 characters");

    Name = name;
    LegalName = legalName;
    TradeName = tradeName;
    Document = document;
  }
}
