using System.Collections;
using Microsoft.EntityFrameworkCore;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.Company;
using RelowFlow_api.Infrastructure.Persistence;

namespace RelowFlow_api.Infrastructure.Repositories;

public class CompanyRepository(AppDbContext context): ICompanyRepository
{
    public async Task<IEnumerable<Company>> FindAllCompanys(Guid userId, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context
                .Companys
                .Include(c => c.Positions.Where(p => p.Deleted == null))
                .Include(c => c.Users.Where(u => u.Deleted == null))
                    .ThenInclude(u => u.User)
                .Where(w => w.UserId == userId && w.Deleted == null)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Get All Companys", e);
        }
    }

    public async Task<Company?> FindCompanyById(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.Companys
                .Include(c => c.Positions.Where(p => p.Deleted == null))
                .Include(c => c.Users.Where(u => u.Deleted == null))
                    .ThenInclude(u => u.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.Deleted == null, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Find Company",e);
        }
    }

    public async Task<Company> CreateCompany(Company company, CancellationToken cancellationToken = default)
    {
        try
        {
            await context.Companys.AddAsync(company, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            string[] columns = {
                "Captação de lead",
                "Primeiro Pagamento",
                "Envio de documentos",
                "Validação de documentos",
                "Seleção do imóvel",
                "Pagamento do imóvel",
                "Assinatura do contrato",
                "Preparação do imóvel",
                "Serviços adicionais",
                "Entrega do imóvel",
                "Pendências",
                "Cancelados"
            };
            
            foreach (var column in columns)
                await context.CompanyPositions.AddAsync(new CompanyPositions
                {
                    CompanyId = company.Id,
                    Name = column
                }, cancellationToken);
            
            await context.SaveChangesAsync(cancellationToken);
            
            return company;
        }
        catch (Exception e)
        {
            throw new Exception("Error on Create company", e);
        }
    }
}