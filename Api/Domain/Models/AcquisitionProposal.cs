using System.ComponentModel.DataAnnotations.Schema;
using MyAcquisition.Api.Infrastructure.Exceptions;

namespace MyAcquisition.Api.Domain.Models;

[Table("AcquisitionProposal")]
public class AcquisitionProposal : BaseModel
{
  [Column("id")]
  public int Id { get; private set; }

  [Column("acquisition_product_id")]
  public int AcquisitionProductId { get; private set; }

  [Column("user_id")]
  public int UserId { get; private set; }

  [Column("price")]
  public decimal Price { get; set; }

  public AcquisitionProduct AcquisitionProduct { get; private set; }
  public User User { get; private set; }

  // Constructors
  public AcquisitionProposal(int id, int acquisitionProductId, int userId, decimal price)
  {
    ModelValidationException.When(id < 0, "Field Id should to be greater than 0");
    Id = id;

    ValidateModel(acquisitionProductId, userId, price);
  }

  public AcquisitionProposal(int acquisitionProductId, int userId, decimal price)
  {
    ValidateModel(acquisitionProductId, userId, price);
  }

  // Validator
  private void ValidateModel(int acquisitionProductId, int userId, decimal price)
  {
    ModelValidationException.When(acquisitionProductId < 0, "Field AcquisitionProductId should to be greater than 0");
    ModelValidationException.When(userId < 0, "Field UserId should to be greater than 0");
    ModelValidationException.When(price < 0, "Field Price should to be greater than 0");

    AcquisitionProductId = acquisitionProductId;
    UserId = userId;
    Price = price;
  }
}
