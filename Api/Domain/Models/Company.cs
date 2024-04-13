using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyAcquisition.Api.Infrastructure.Exceptions;

namespace MyAcquisition.Api.Domain.Models;

public class Company
{
  [Column("id")]
  public int Id { get; set; }

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

  [Required]
  [Column("phone")]
  [StringLength(15)]
  public string Phone { get; set; }

  [Required]
  [Column("email")]
  [StringLength(70)]
  [RegularExpression(@"b[A-Z0-9._%-]+@[A-Z0-9.-]+.[A-Z]{2,4}b", ErrorMessage = "Email format is invalid")]
  public string Email { get; set; }

  [Required]
  [Column("zip_code")]
  [StringLength(8)]
  public string ZipCode { get; set; }

  [Required]
  [Column("street_name")]
  [StringLength(100)]
  public string StreetName { get; set; }

  [Required]
  [Column("street_number")]
  [StringLength(7)]
  public string StreetNumber { get; set; }

  [Required]
  [Column("neighborhood")]
  [StringLength(50)]
  public string Neighborhood { get; set; }

  [Required]
  [Column("complement")]
  [StringLength(100)]
  public string Complement { get; set; }

  [Required]
  [Column("city")]
  [StringLength(50)]
  public string City { get; set; }

  [Required]
  [Column("state")]
  [StringLength(2)]
  public string State { get; set; }

  public Company(int id, string legalName, string tradeName, string document, string phone,
                 string email, string zipCode, string streetName, string streetNumber,
                 string neighborhood, string complement, string city, string state)
  {
    ModelValidationException.When(id < 0, "Field Id should to be greater than 0");
    Id = id;

    ValidateModel(legalName, tradeName, document, phone, email, zipCode,
                  streetName, streetNumber, neighborhood, complement, city, state);
  }

  public Company(string legalName, string tradeName, string document, string phone,
                 string email, string zipCode, string streetName, string streetNumber,
                 string neighborhood, string complement, string city, string state)
  {
    ValidateModel(legalName, tradeName, document, phone,
                  email, zipCode, streetName, streetNumber,
                  neighborhood, complement, city, state);
  }

  private void ValidateModel(string legalName, string tradeName, string document, string phone,
                             string email, string zipCode, string streetName, string streetNumber,
                             string neighborhood, string complement, string city, string state)
  {
    ModelValidationException.When(legalName == null, "Field LegalName is required");
    ModelValidationException.When(tradeName == null, "Field TradeName is required");
    ModelValidationException.When(document == null, "Field Document is required");
    ModelValidationException.When(phone == null, "Field Phone is required");
    ModelValidationException.When(email == null, "Field Email is required");
    ModelValidationException.When(zipCode == null, "Field ZipCode is required");
    ModelValidationException.When(streetName == null, "Field StreetName is required");
    ModelValidationException.When(streetNumber == null, "Field StreetNumber is required");
    ModelValidationException.When(neighborhood == null, "Field Neighborhood is required");
    ModelValidationException.When(complement == null, "Field Complement is required");
    ModelValidationException.When(city == null, "Field City is required");
    ModelValidationException.When(state == null, "Field State is required");

    ModelValidationException.When(legalName.Length > 100, "Maximum size for LegalName is 100 characters");
    ModelValidationException.When(tradeName.Length > 100, "Maximum size for TradeName is 100 characters");
    ModelValidationException.When(document.Length > 14, "Maximum size for Document is 100 characters");
    ModelValidationException.When(phone.Length > 100, "Maximum size for Phone is 15 characters");
    ModelValidationException.When(email.Length > 100, "Maximum size for Email is 70 characters");
    ModelValidationException.When(zipCode.Length > 100, "Maximum size for ZipCode is 8 characters");
    ModelValidationException.When(streetName.Length > 100, "Maximum size for StreetName is 100 characters");
    ModelValidationException.When(streetNumber.Length > 100, "Maximum size for StreetNumber is 7 characters");
    ModelValidationException.When(neighborhood.Length > 100, "Maximum size for Neighborhood is 50 characters");
    ModelValidationException.When(complement.Length > 100, "Maximum size for Complement is 100 characters");
    ModelValidationException.When(city.Length > 100, "Maximum size for City is 50 characters");
    ModelValidationException.When(state.Length > 100, "Maximum size for State is 2 characters");

    LegalName = legalName;
    TradeName = tradeName;
    Document = document;
    Phone = phone;
    Email = email.ToLower();
    ZipCode = zipCode;
    StreetName = streetName;
    StreetNumber = streetNumber;
    Neighborhood = neighborhood;
    Complement = complement;
    City = city;
    State = state;
  }
}
