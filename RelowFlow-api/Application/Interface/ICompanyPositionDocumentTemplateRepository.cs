using RelowFlow_api.Domain.Entities.Company;

namespace RelowFlow_api.Application.Interface;

public interface ICompanyPositionDocumentTemplateRepository
{
    Task<IEnumerable<CompanyPositionDocumentTemplate>> FindAllDocumentTemplates(Guid companyPositionId, CancellationToken cancellationToken = default);
    Task<CompanyPositionDocumentTemplate?> FindDocumentTemplateById(Guid id, CancellationToken cancellationToken = default);
    Task<CompanyPositionDocumentTemplate> CreateDocumentTemplate(CompanyPositionDocumentTemplate template, CancellationToken cancellationToken = default);
    Task<CompanyPositionDocumentTemplate> UpdateDocumentTemplate(CompanyPositionDocumentTemplate template, CancellationToken cancellationToken = default);
    Task<bool> DeleteDocumentTemplate(CompanyPositionDocumentTemplate template, CancellationToken cancellationToken = default);
}

