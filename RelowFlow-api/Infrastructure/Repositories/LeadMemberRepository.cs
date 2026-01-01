using Microsoft.EntityFrameworkCore;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.Lead;
using RelowFlow_api.Infrastructure.Persistence;

namespace RelowFlow_api.Infrastructure.Repositories;

public class LeadMemberRepository(AppDbContext context) : ILeadMemberRepository
{
    public async Task<IEnumerable<LeadMember>> FindAllLeadMembers(Guid leadId, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.LeadMembers
                .Include(lm => lm.User)
                .Where(lm => lm.LeadId == leadId && lm.Deleted == null)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Find All Lead Members", e);
        }
    }

    public async Task<LeadMember?> FindLeadMemberById(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await context.LeadMembers
                .Include(lm => lm.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(lm => lm.Id == id && lm.Deleted == null, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception("Error on Find Lead Member by Id", e);
        }
    }

    public async Task<LeadMember> CreateLeadMember(LeadMember leadMember, CancellationToken cancellationToken = default)
    {
        try
        {
            await context.LeadMembers.AddAsync(leadMember, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return leadMember;
        }
        catch (Exception e)
        {
            throw new Exception("Error on Create Lead Member", e);
        }
    }

    public async Task<LeadMember> UpdateLeadMember(LeadMember leadMember, CancellationToken cancellationToken = default)
    {
        try
        {
            var existingMember = await context.LeadMembers
                .FirstOrDefaultAsync(lm => lm.Id == leadMember.Id && lm.Deleted == null, cancellationToken);

            if (existingMember == null)
            {
                throw new Exception($"Lead Member with Id {leadMember.Id} not found");
            }

            existingMember.Name = leadMember.Name;
            existingMember.UserId = leadMember.UserId;
            existingMember.Updated = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);
            return existingMember;
        }
        catch (Exception e)
        {
            throw new Exception("Error on Update Lead Member", e);
        }
    }

    public async Task<bool> DeleteLeadMember(LeadMember leadMember, CancellationToken cancellationToken = default)
    {
        try
        {
            var existingMember = await context.LeadMembers
                .FirstOrDefaultAsync(lm => lm.Id == leadMember.Id && lm.Deleted == null, cancellationToken);

            if (existingMember == null)
            {
                throw new Exception($"Lead Member with Id {leadMember.Id} not found");
            }

            // Soft Delete
            existingMember.Deleted = DateTime.UtcNow;
            existingMember.Updated = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("Error on Delete Lead Member", e);
        }
    }
}

