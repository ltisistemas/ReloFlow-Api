namespace RelowFlow_api.Application.Dtos;

public record LeadCreateDtoRequest(Guid CompanyId, Guid CompanyPositionId, string Name, string Description);

public record LeadCreateDtoServiceRequest(Guid UserId, Guid CompanyId, Guid CompanyPositionId, string Name, string Description);

public record LeadUpdateDtoRequest(
    Guid Id,
    string Name,
    string Description,
    decimal? Amount,
    string Currency,
    string? ZipCode,
    string? StreetAddress,
    string? StreetAddressNumber,
    string? StreetAddressComplement,
    string? City,
    string? State,
    string? Country,
    Guid CompanyId,
    Guid CompanyPositionId
);

public record LeadUpdateDtoServiceRequest(
    Guid Id,
    string Name,
    string Description,
    decimal? Amount,
    string Currency,
    string? ZipCode,
    string? StreetAddress,
    string? StreetAddressNumber,
    string? StreetAddressComplement,
    string? City,
    string? State,
    string? Country,
    Guid CompanyId,
    Guid CompanyPositionId
);

public record LeadUpdatePositionDtoRequest(Guid CompanyPositionId);

public record LeadMemberCreateDtoRequest(Guid LeadId, Guid? UserId, string? Name);
public record LeadMemberCreateDtoServiceRequest(Guid LeadId, Guid? UserId, string? Name);
public record LeadMemberUpdateDtoRequest(Guid? UserId, string? Name);
public record LeadMemberUpdateDtoServiceRequest(Guid Id, Guid? UserId, string? Name);

public record LeadMemberDtoResponse(
    Guid Id,
    Guid LeadId,
    Guid? UserId,
    string? Name,
    DateTime Created,
    DateTime Updated,
    DateTime? Deleted
);

public record LeadDtoResponse(
    Guid Id,
    Guid UserId,
    Guid CompanyId,
    Guid CompanyPositionId,
    string Name,
    string Description,
    decimal? Amount,
    string Currency,
    string? ZipCode,
    string? StreetAddress,
    string? StreetAddressNumber,
    string? StreetAddressComplement,
    string? City,
    string? State,
    string? Country,
    IEnumerable<LeadMemberDtoResponse>? Members,
    DateTime Created,
    DateTime Updated,
    DateTime? Deleted
);