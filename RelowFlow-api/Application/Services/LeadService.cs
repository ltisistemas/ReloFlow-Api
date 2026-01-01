using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.Lead;

namespace RelowFlow_api.Application.Services;

public class LeadService(ILeadRepository repository): ILeadService
{
    public async Task<IEnumerable<LeadDtoResponse>> FindAllLeads(Guid companyId, CancellationToken cancellationToken = default)
    {
        var entities = await repository.FindAllLeads(companyId, cancellationToken);
        return entities.Select(MapToDto).Where(dto => dto != null)!;
    }

    public async Task<LeadDtoResponse?> FindLeadById(Guid id, CancellationToken cancellationToken = default)
    {
        return MapToDto(await repository.FindLeadById(id, cancellationToken));
    }

    public async Task<LeadDtoResponse?> CreateLead(LeadCreateDtoServiceRequest lead, CancellationToken cancellationToken = default)
    {
        // Timestamps serão setados automaticamente pelo AuditInterceptor
        var entity = new Lead()
        {
            UserId = lead.UserId,
            CompanyId = lead.CompanyId,
            CompanyPositionId = lead.CompanyPositionId,
            Name = lead.Name,
            Description = lead.Description
        };
    
        return MapToDto(await repository.CreateLead(entity, cancellationToken));
    }

    public async Task<LeadDtoResponse?> UpdateLead(LeadUpdateDtoServiceRequest lead, CancellationToken cancellationToken = default)
    {
        var existingLead = await repository.FindLeadById(lead.Id, cancellationToken);
        
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

        return MapToDto(await repository.UpdateLead(existingLead, cancellationToken));
    }

    public async Task<bool> DeleteLead(Guid id, CancellationToken cancellationToken = default)
    {
        var existingLead = await repository.FindLeadById(id, cancellationToken);
        
        if (existingLead == null)
        {
            throw new Exception($"Lead with Id {id} not found");
        }

        return await repository.DeleteLead(existingLead, cancellationToken);
    }

    public async Task<LeadDtoResponse?> UpdateLeadPosition(Guid leadId, Guid companyPositionId, CancellationToken cancellationToken = default)
    {
        var existingLead = await repository.FindLeadById(leadId, cancellationToken);
        
        if (existingLead == null)
        {
            throw new Exception($"Lead with Id {leadId} not found");
        }

        // Atualizar apenas o CompanyPositionId (movimentação no Kanban)
        existingLead.CompanyPositionId = companyPositionId;

        return MapToDto(await repository.UpdateLead(existingLead, cancellationToken));
    }
    
    private LeadDtoResponse? MapToDto(Lead? lead)
    {
        if (lead != null)
            return new LeadDtoResponse(
                lead.Id,
                lead.UserId,
                lead.CompanyId,
                lead.CompanyPositionId,
                lead.Name,
                lead.Description,
                lead.Amount,
                lead.Currency,
                lead.ZipCode,
                lead.StreetAddress,
                lead.StreetAddressNumber,
                lead.StreetAddressComplement,
                lead.City,
                lead.State,
                lead.Country,
                (lead.Members ?? []).Select(m => new LeadMemberDtoResponse(
                    m.Id,
                    m.LeadId,
                    m.UserId,
                    m.Name,
                    m.Created,
                    m.Updated,
                    m.Deleted
                )),
                lead.Created,
                lead.Updated,
                lead.Deleted
            );

        return null;
    }
}