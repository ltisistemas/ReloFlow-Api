using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.Company;
using RelowFlow_api.Domain.Entities.Lead;

namespace RelowFlow_api.Application.Services;

public class CompanyPositionDocumentTemplateService(ICompanyPositionDocumentTemplateRepository repository) : ICompanyPositionDocumentTemplateService
{
    public async Task<IEnumerable<CompanyPositionDocumentTemplateDtoResponse>> FindAllDocumentTemplates(Guid companyPositionId, CancellationToken cancellationToken = default)
    {
        var entities = await repository.FindAllDocumentTemplates(companyPositionId, cancellationToken);
        return entities.Select(MapToDto).Where(dto => dto != null)!;
    }

    public async Task<CompanyPositionDocumentTemplateDtoResponse?> FindDocumentTemplateById(Guid id, CancellationToken cancellationToken = default)
    {
        return MapToDto(await repository.FindDocumentTemplateById(id, cancellationToken));
    }

    public async Task<CompanyPositionDocumentTemplateDtoResponse?> CreateDocumentTemplate(CompanyPositionDocumentTemplateCreateDtoServiceRequest request, CancellationToken cancellationToken = default)
    {
        var entity = new CompanyPositionDocumentTemplate
        {
            CompanyPositionId = request.CompanyPositionId,
            Name = request.Name,
            DocumentType = request.DocumentType,
            IsRequired = request.IsRequired,
            TargetType = (DocumentTargetType)request.TargetType
        };

        return MapToDto(await repository.CreateDocumentTemplate(entity, cancellationToken));
    }

    public async Task<CompanyPositionDocumentTemplateDtoResponse?> UpdateDocumentTemplate(CompanyPositionDocumentTemplateUpdateDtoServiceRequest request, CancellationToken cancellationToken = default)
    {
        var existing = await repository.FindDocumentTemplateById(request.Id, cancellationToken);
        
        if (existing == null)
        {
            throw new Exception($"Document Template with Id {request.Id} not found");
        }

        existing.Name = request.Name;
        existing.DocumentType = request.DocumentType;
        existing.IsRequired = request.IsRequired;
        existing.TargetType = (DocumentTargetType)request.TargetType;

        return MapToDto(await repository.UpdateDocumentTemplate(existing, cancellationToken));
    }

    public async Task<bool> DeleteDocumentTemplate(Guid id, CancellationToken cancellationToken = default)
    {
        var existing = await repository.FindDocumentTemplateById(id, cancellationToken);
        
        if (existing == null)
        {
            throw new Exception($"Document Template with Id {id} not found");
        }

        return await repository.DeleteDocumentTemplate(existing, cancellationToken);
    }

    private CompanyPositionDocumentTemplateDtoResponse? MapToDto(CompanyPositionDocumentTemplate? template)
    {
        if (template != null)
            return new CompanyPositionDocumentTemplateDtoResponse(
                template.Id,
                template.CompanyPositionId,
                template.Name,
                template.DocumentType,
                template.IsRequired,
                (int)template.TargetType,
                template.Created,
                template.Updated,
                template.Deleted
            );

        return null;
    }
}

