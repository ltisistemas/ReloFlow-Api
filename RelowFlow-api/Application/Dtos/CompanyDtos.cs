namespace RelowFlow_api.Application.Dtos;

public record CompanyCreateDtoRequest(Guid UserId, string Name, string Description);

public record CompanyUserCreateDtoRequest(Guid CompanyId, Guid UserId);
public record CompanyUserCreateDtoServiceRequest(Guid CompanyId, Guid UserId);

public record CompanyUserDtoResponse(
    Guid Id,
    Guid CompanyId,
    Guid UserId,
    DateTime Created,
    DateTime Updated,
    DateTime? Deleted
);

public record CompanyPositionDocumentTemplateCreateDtoRequest(
    Guid CompanyPositionId,
    string Name,
    string DocumentType,
    bool IsRequired,
    int TargetType
);
public record CompanyPositionDocumentTemplateCreateDtoServiceRequest(
    Guid CompanyPositionId,
    string Name,
    string DocumentType,
    bool IsRequired,
    int TargetType
);
public record CompanyPositionDocumentTemplateUpdateDtoRequest(
    string Name,
    string DocumentType,
    bool IsRequired,
    int TargetType
);
public record CompanyPositionDocumentTemplateUpdateDtoServiceRequest(
    Guid Id,
    string Name,
    string DocumentType,
    bool IsRequired,
    int TargetType
);

public record CompanyPositionDocumentTemplateDtoResponse(
    Guid Id,
    Guid CompanyPositionId,
    string Name,
    string DocumentType,
    bool IsRequired,
    int TargetType,
    DateTime Created,
    DateTime Updated,
    DateTime? Deleted
);

public record CompanyPositionsDtoResponse(
    Guid Id,
    Guid CompanyId,
    string Name,
    IEnumerable<CompanyPositionDocumentTemplateDtoResponse>? DocumentTemplates,
    DateTime Created,
    DateTime Updated,
    DateTime? Deleted
);

public record CompanyDtoResponse(
    Guid Id,
    Guid UserId,
    string Name,
    string Description,
    string FinancialCode,
    IEnumerable<CompanyUserDtoResponse>? Users,
    DateTime Created, DateTime Updated,
    DateTime? Deleted,
    IEnumerable<CompanyPositionsDtoResponse> Positions
    );

    
