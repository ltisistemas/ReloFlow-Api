using Microsoft.EntityFrameworkCore;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.Company;
using RelowFlow_api.Infrastructure.Persistence;

namespace RelowFlow_api.Infrastructure.Repositories;

public class CompanyUserRepository(AppDbContext context) : ICompanyUserRepository
{
    public async Task<IEnumerable<CompanyUser>> FindAllCompanyUsers(Guid companyId, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.CompanyUsers
                .Include(cu => cu.User)
                .Where(cu => cu.CompanyId == companyId && cu.Deleted == null)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Find All Company Users", e);
        }
    }

    public async Task<CompanyUser?> FindCompanyUserById(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.CompanyUsers
                .Include(cu => cu.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(cu => cu.Id == id && cu.Deleted == null, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Find Company User by Id", e);
        }
    }

    public async Task<CompanyUser?> FindCompanyUserByCompanyAndUser(Guid companyId, Guid userId, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.CompanyUsers
                .Include(cu => cu.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(cu => cu.CompanyId == companyId && cu.UserId == userId && cu.Deleted == null, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Find Company User by Company and User", e);
        }
    }

    public async Task<CompanyUser> CreateCompanyUser(CompanyUser companyUser, CancellationToken cancellationToken = default)
    {
        try
        {
            // Verificar se já existe
            var existing = await FindCompanyUserByCompanyAndUser(companyUser.CompanyId, companyUser.UserId, cancellationToken);
            if (existing != null)
            {
                throw new Exception("User is already associated with this company");
            }

            await context.CompanyUsers.AddAsync(companyUser, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return companyUser;
        }
        catch (Exception e)
        {
            throw new Exception("Error on Create Company User", e);
        }
    }

    public async Task<bool> DeleteCompanyUser(CompanyUser companyUser, CancellationToken cancellationToken = default)
    {
        try
        {
            var existing = await context.CompanyUsers
                .FirstOrDefaultAsync(cu => cu.Id == companyUser.Id && cu.Deleted == null, cancellationToken);

            if (existing == null)
            {
                throw new Exception($"Company User with Id {companyUser.Id} not found");
            }

            // Soft Delete
            existing.Deleted = DateTime.UtcNow;
            existing.Updated = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("Error on Delete Company User", e);
        }
    }
}

