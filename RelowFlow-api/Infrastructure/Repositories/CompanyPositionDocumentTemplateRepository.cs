using Microsoft.EntityFrameworkCore;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.Company;
using RelowFlow_api.Infrastructure.Persistence;

namespace RelowFlow_api.Infrastructure.Repositories;

public class CompanyPositionDocumentTemplateRepository(AppDbContext context) : ICompanyPositionDocumentTemplateRepository
{
    public async Task<IEnumerable<CompanyPositionDocumentTemplate>> FindAllDocumentTemplates(Guid companyPositionId, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.CompanyPositionDocumentTemplates
                .Where(t => t.CompanyPositionId == companyPositionId && t.Deleted == null)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Find All Document Templates", e);
        }
    }

    public async Task<CompanyPositionDocumentTemplate?> FindDocumentTemplateById(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.CompanyPositionDocumentTemplates
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id && t.Deleted == null, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Find Document Template by Id", e);
        }
    }

    public async Task<CompanyPositionDocumentTemplate> CreateDocumentTemplate(CompanyPositionDocumentTemplate template, CancellationToken cancellationToken = default)
    {
        try
        {
            await context.CompanyPositionDocumentTemplates.AddAsync(template, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return template;
        }
        catch (Exception e)
        {
            throw new Exception("Error on Create Document Template", e);
        }
    }

    public async Task<CompanyPositionDocumentTemplate> UpdateDocumentTemplate(CompanyPositionDocumentTemplate template, CancellationToken cancellationToken = default)
    {
        try
        {
            var existing = await context.CompanyPositionDocumentTemplates
                .FirstOrDefaultAsync(t => t.Id == template.Id && t.Deleted == null, cancellationToken);

            if (existing == null)
            {
                throw new Exception($"Document Template with Id {template.Id} not found");
            }

            existing.Name = template.Name;
            existing.DocumentType = template.DocumentType;
            existing.IsRequired = template.IsRequired;
            existing.TargetType = template.TargetType;
            existing.Updated = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);
            return existing;
        }
        catch (Exception e)
        {
            throw new Exception("Error on Update Document Template", e);
        }
    }

    public async Task<bool> DeleteDocumentTemplate(CompanyPositionDocumentTemplate template, CancellationToken cancellationToken = default)
    {
        try
        {
            var existing = await context.CompanyPositionDocumentTemplates
                .FirstOrDefaultAsync(t => t.Id == template.Id && t.Deleted == null, cancellationToken);

            if (existing == null)
            {
                throw new Exception($"Document Template with Id {template.Id} not found");
            }

            // Soft Delete
            existing.Deleted = DateTime.UtcNow;
            existing.Updated = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("Error on Delete Document Template", e);
        }
    }
}

