using RelowFlow_api.Application.Dtos;

namespace RelowFlow_api.Application.Interface;

public interface ICompanyPositionDocumentTemplateService
{
    Task<IEnumerable<CompanyPositionDocumentTemplateDtoResponse>> FindAllDocumentTemplates(Guid companyPositionId, CancellationToken cancellationToken = default);
    Task<CompanyPositionDocumentTemplateDtoResponse?> FindDocumentTemplateById(Guid id, CancellationToken cancellationToken = default);
    Task<CompanyPositionDocumentTemplateDtoResponse?> CreateDocumentTemplate(CompanyPositionDocumentTemplateCreateDtoServiceRequest request, CancellationToken cancellationToken = default);
    Task<CompanyPositionDocumentTemplateDtoResponse?> UpdateDocumentTemplate(CompanyPositionDocumentTemplateUpdateDtoServiceRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteDocumentTemplate(Guid id, CancellationToken cancellationToken = default);
}

