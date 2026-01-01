using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.Lead;

namespace RelowFlow_api.Application.Services;

public class LeadMemberService(ILeadMemberRepository repository) : ILeadMemberService
{
    public async Task<IEnumerable<LeadMemberDtoResponse>> FindAllLeadMembers(Guid leadId, CancellationToken cancellationToken = default)
    {
        var entities = await repository.FindAllLeadMembers(leadId, cancellationToken);
        return entities.Select(MapToDto).Where(dto => dto != null)!;
    }

    public async Task<LeadMemberDtoResponse?> FindLeadMemberById(Guid id, CancellationToken cancellationToken = default)
    {
        return MapToDto(await repository.FindLeadMemberById(id, cancellationToken));
    }

    public async Task<LeadMemberDtoResponse?> CreateLeadMember(LeadMemberCreateDtoServiceRequest request, CancellationToken cancellationToken = default)
    {
        var entity = new LeadMember
        {
            LeadId = request.LeadId,
            UserId = request.UserId,
            Name = request.Name
        };

        return MapToDto(await repository.CreateLeadMember(entity, cancellationToken));
    }

    public async Task<LeadMemberDtoResponse?> UpdateLeadMember(LeadMemberUpdateDtoServiceRequest request, CancellationToken cancellationToken = default)
    {
        var existing = await repository.FindLeadMemberById(request.Id, cancellationToken);
        
        if (existing == null)
        {
            throw new Exception($"Lead Member with Id {request.Id} not found");
        }

        existing.UserId = request.UserId;
        existing.Name = request.Name;

        return MapToDto(await repository.UpdateLeadMember(existing, cancellationToken));
    }

    public async Task<bool> DeleteLeadMember(Guid id, CancellationToken cancellationToken = default)
    {
        var existing = await repository.FindLeadMemberById(id, cancellationToken);
        
        if (existing == null)
        {
            throw new Exception($"Lead Member with Id {id} not found");
        }

        return await repository.DeleteLeadMember(existing, cancellationToken);
    }

    private LeadMemberDtoResponse? MapToDto(LeadMember? member)
    {
        if (member != null)
            return new LeadMemberDtoResponse(
                member.Id,
                member.LeadId,
                member.UserId,
                member.Name,
                member.Created,
                member.Updated,
                member.Deleted
            );

        return null;
    }
}

