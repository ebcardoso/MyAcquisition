using MyAcquisition.Api.Domain.Enums;

namespace MyAcquisition.Api.Application.DTO;

public record ProductGetDTO(int Id, int BrandId, string Name, Units Unit, string Quantity);
