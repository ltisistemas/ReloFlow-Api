using Microsoft.EntityFrameworkCore;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.Lead;
using RelowFlow_api.Infrastructure.Persistence;

namespace RelowFlow_api.Infrastructure.Repositories;

public class LeadRepository(AppDbContext context): ILeadRepository
{
    public async Task<IEnumerable<Lead>> FindAllLeads(Guid companyId, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.Leads
                .Include(l => l.Members.Where(m => m.Deleted == null))
                    .ThenInclude(m => m.User)
                .Include(l => l.CompanyPosition)
                .Where(l => l.CompanyId == companyId && l.Deleted == null)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Find All Leads", e);
        }
    }

    public async Task<Lead?> FindLeadById(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.Leads
                .Include(l => l.Members.Where(m => m.Deleted == null))
                    .ThenInclude(m => m.User)
                .Include(l => l.Company)
                .Include(l => l.CompanyPosition)
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id && l.Deleted == null, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Find Lead by Id", e);
        }
    }

    public async Task<Lead> CreateLead(Lead lead, CancellationToken cancellationToken = default)
    {
        try
        {
            await context.Leads.AddAsync(lead, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return lead;
        }
        catch (Exception e)
        {
            throw new Exception("Error on Create Lead", e);
        }
    }

    public async Task<Lead> UpdateLead(Lead lead, CancellationToken cancellationToken = default)
    {
        try
        {
            var existingLead = await context.Leads
                .FirstOrDefaultAsync(l => l.Id == lead.Id && l.Deleted == null, cancellationToken);

            if (existingLead == null)
            {
                throw new Exception($"Lead with Id {lead.Id} not found");
            }

            // Atualizar propriedades
            existingLead.Name = lead.Name;
            existingLead.Description = lead.Description;
            existingLead.Amount = lead.Amount;
            existingLead.Currency = lead.Currency;
            existingLead.ZipCode = lead.ZipCode;
            existingLead.StreetAddress = lead.StreetAddress;
            existingLead.StreetAddressNumber = lead.StreetAddressNumber;
            existingLead.StreetAddressComplement = lead.StreetAddressComplement;
            existingLead.City = lead.City;
            existingLead.State = lead.State;
            existingLead.Country = lead.Country;
            existingLead.CompanyId = lead.CompanyId;
            existingLead.CompanyPositionId = lead.CompanyPositionId;
            existingLead.Updated = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);

            return existingLead;
        }
        catch (Exception e)
        {
            throw new Exception("Error on Update Lead", e);
        }
    }

    public async Task<bool> DeleteLead(Lead lead, CancellationToken cancellationToken = default)
    {
        try
        {
            var existingLead = await context.Leads
                .FirstOrDefaultAsync(l => l.Id == lead.Id && l.Deleted == null, cancellationToken);

            if (existingLead == null)
            {
                throw new Exception($"Lead with Id {lead.Id} not found");
            }

            // Soft Delete
            existingLead.Deleted = DateTime.UtcNow;
            existingLead.Updated = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);

            return true;
        }
        catch (Exception e)
        {
            throw new Exception("Error on Delete Lead", e);
        }
    }
}