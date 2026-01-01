using RelowFlow_api.Domain.Entities.Lead;

namespace RelowFlow_api.Application.Interface;

public interface ILeadMemberRepository
{
    Task<IEnumerable<LeadMember>> FindAllLeadMembers(Guid leadId, CancellationToken cancellationToken = default);
    Task<LeadMember?> FindLeadMemberById(Guid id, CancellationToken cancellationToken = default);
    Task<LeadMember> CreateLeadMember(LeadMember leadMember, CancellationToken cancellationToken = default);
    Task<LeadMember> UpdateLeadMember(LeadMember leadMember, CancellationToken cancellationToken = default);
    Task<bool> DeleteLeadMember(LeadMember leadMember, CancellationToken cancellationToken = default);
}

