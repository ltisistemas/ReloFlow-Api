using Microsoft.EntityFrameworkCore;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.Company;
using RelowFlow_api.Infrastructure.Persistence;

namespace RelowFlow_api.Infrastructure.Repositories;

public class CompanyPositionRepository(AppDbContext context): ICompanyPositionRepository
{
    public async Task<IEnumerable<CompanyPositions>> FindAllCompanyPositions(CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.CompanyPositions.AsNoTracking().ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Get All Companys Positions", e);
        }
    }

    public async Task<CompanyPositions?> FindCompanyPositionsById(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.CompanyPositions
                .Include(cp => cp.DocumentTemplates.Where(t => t.Deleted == null))
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.Deleted == null, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Find Company Position",e);
        }
    }

    public async Task<IEnumerable<CompanyPositions>> FindCompanyPositionsByCompanyId(Guid companyId, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context
                .CompanyPositions
                .Include(cp => cp.DocumentTemplates.Where(t => t.Deleted == null))
                .AsNoTracking()
                .Where(w => w.CompanyId == companyId && w.Deleted == null)
                .ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Get All Companys Positions", e);
        }
    }
}