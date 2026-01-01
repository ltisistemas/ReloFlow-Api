using RelowFlow_api.Domain.Entities.User;

namespace RelowFlow_api.Application.Dtos;

public record UserDtoResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    GenderEnum Gender,
    string Nif,
    string Niss,
    string RegisterNumber,
    string Nacionalidad,
    string Naturalidad,
    string Profession,
    decimal? Salary,
    string ZipCode,
    string StreetAddress,
    string StreetAddressNumber,
    string StreetAddressComplement,
    string City,
    string State,
    string Country,
    string PassportNumber,
    DateOnly? PassportCreated,
    DateOnly? PassportExpires,
    bool HasVisa,
    DateOnly? VisaStartDate,
    DateOnly? VisaEndDate,
    string AnotherInformation,
    bool ResetPassword,
    DateTime? LastLogin,
    UserStatusEnum Status,
    DateTime CreatedAt,
    DateTime UpdatedAt
);