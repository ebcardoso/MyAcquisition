using System.ComponentModel.DataAnnotations.Schema;
using MyAcquisition.Api.Infrastructure.Exceptions;

namespace MyAcquisition.Api.Domain.Models;

[Table("AcquisitionProduct")]
public class AcquisitionProduct : BaseModel
{
  [Column("id")]
  public int Id { get; private set; }

  [Column("acquisition_id")]
  public int AcquisitionId { get; private set; }

  [Column("product_id")]
  public int ProductId { get; private set; }

  [Column("amount")]
  public int Amount { get; set; }

  public Acquisition Acquisition { get; set; }

  public Product Product { get; set; }

  // Constructors
  public AcquisitionProduct(int id, int acquisitionId, int productId, int amount)
  {
    ModelValidationException.When(id < 0, "Field Id should to be greater than 0");
    Id = id;

    ValidateModel(acquisitionId, productId, amount);
  }

  public AcquisitionProduct(int acquisitionId, int productId, int amount)
  {
    ValidateModel(acquisitionId, productId, amount);
  }

  // Validator
  private void ValidateModel(int acquisitionId, int productId, int amount)
  {
    ModelValidationException.When(acquisitionId < 0, "Field AcquisitionId should to be greater than 0");
    ModelValidationException.When(productId < 0, "Field ProductId should to be greater than 0");
    ModelValidationException.When(amount < 0, "Field Amount should to be greater than 0");

    AcquisitionId = acquisitionId;
    ProductId = productId;
    Amount = amount;
  }
}
