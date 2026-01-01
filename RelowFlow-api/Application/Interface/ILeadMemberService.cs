using RelowFlow_api.Application.Dtos;

namespace RelowFlow_api.Application.Interface;

public interface ILeadMemberService
{
    Task<IEnumerable<LeadMemberDtoResponse>> FindAllLeadMembers(Guid leadId, CancellationToken cancellationToken = default);
    Task<LeadMemberDtoResponse?> FindLeadMemberById(Guid id, CancellationToken cancellationToken = default);
    Task<LeadMemberDtoResponse?> CreateLeadMember(LeadMemberCreateDtoServiceRequest request, CancellationToken cancellationToken = default);
    Task<LeadMemberDtoResponse?> UpdateLeadMember(LeadMemberUpdateDtoServiceRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteLeadMember(Guid id, CancellationToken cancellationToken = default);
}

