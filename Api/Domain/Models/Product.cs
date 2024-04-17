using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyAcquisition.Api.Domain.Enums;
using MyAcquisition.Api.Infrastructure.Exceptions;

namespace  MyAcquisition.Api.Domain.Models;

[Table("Product")]
public class Product : BaseModel
{
  public int Id { get; private set; }

  [Column("brand_id")]
  public int BrandId { get; private set; }

  [Column("company_id")]
  public int CompanyId { get; private set; }

  [Required]
  [Column("name")]
  [StringLength(100)]
  public string Name { get; set; }
  
  [Required]
  [Column("unit")]
  public Units Unit { get; set; }

  [Required]
  [Column("quantity")]
  [StringLength(10)]
  public string Quantity { get; set; }

  public Brand Brand { get; set; }
  public Company Company { get; set; }

  public Product(int id, int brandId, int companyId, string name, Units unit, string amount)
  {
    ModelValidationException.When(id < 0, "Field Id should to be greater than 0");
    Id = id;

    ValidateModel(brandId, companyId, name, unit, amount);
  }

  public Product(int brandId, int companyId, string name, Units unit, string quantity)
  {
    ValidateModel(brandId, companyId, name, unit, quantity);
  }

  private void ValidateModel(int brandId, int companyId, string name, Units unit, string quantity)
  {
    ModelValidationException.When(brandId < 0, "Field BrandId should to be greater than 0");
    ModelValidationException.When(companyId < 0, "Field CompanyId should to be greater than 0");
    ModelValidationException.When(name == null, "Field Name is required");
    ModelValidationException.When(quantity == null, "Field Quantity is required");

    ModelValidationException.When(name.Length > 100, "Maximum size for Name is 100 characters");
    ModelValidationException.When(quantity.Length > 10, "Maximum size for TradeName is 100 characters");

    BrandId = brandId;
    CompanyId = companyId;
    Name = name;
    Unit = unit;
    Quantity = quantity;
  }
}
