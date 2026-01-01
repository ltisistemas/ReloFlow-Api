using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Exceptions;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.Company;

namespace RelowFlow_api.Application.Services;

public class CompanyService(ICompanyRepository repository): ICompanyService
{
    public async Task<IEnumerable<CompanyDtoResponse>> FindAllCompanys(
        Guid userId, 
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.FindAllCompanys(userId, cancellationToken);
        return entities.Select(MapToDto);
    }

    public async Task<CompanyDtoResponse?> FindCompanyById(
        Guid id, 
        CancellationToken cancellationToken = default)
    {
        return MapToDto(await repository.FindCompanyById(id, cancellationToken));
    }

    public async Task<CompanyDtoResponse?> CreateCompany(
        CompanyCreateDtoRequest company, 
        CancellationToken cancellationToken = default)
    {
        // Timestamps serão setados automaticamente pelo AuditInterceptor
        var entity = new Company()
        {
            UserId = company.UserId,
            Name = company.Name,
            Description = company.Description
        };
    
        return MapToDto(await repository.CreateCompany(entity, cancellationToken));
    }
    
    private CompanyDtoResponse? MapToDto(Company? company)
    {
        if (company != null)
            return new CompanyDtoResponse(
                company.Id,
                company.UserId,
                company.Name,
                company.Description,
                company.FinancialCode,
                (company.Users ?? []).Select(u => new CompanyUserDtoResponse(
                    u.Id,
                    u.CompanyId,
                    u.UserId,
                    u.Created,
                    u.Updated,
                    u.Deleted
                )),
                company.Created,
                company.Updated,
                company.Deleted,
                (company.Positions ?? []).Select(p => new CompanyPositionsDtoResponse(
                    p.Id,
                    p.CompanyId,
                    p.Name,
                    (p.DocumentTemplates ?? []).Select(t => new CompanyPositionDocumentTemplateDtoResponse(
                        t.Id,
                        t.CompanyPositionId,
                        t.Name,
                        t.DocumentType,
                        t.IsRequired,
                        (int)t.TargetType,
                        t.Created,
                        t.Updated,
                        t.Deleted
                    )),
                    p.Created,
                    p.Updated,
                    p.Deleted
                ))
            );

        return null;
    }
}