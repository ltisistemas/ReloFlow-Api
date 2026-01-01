using RelowFlow_api.Application.Dtos;

namespace RelowFlow_api.Application.Interface;

public interface ILeadService
{
    public Task<IEnumerable<LeadDtoResponse>> FindAllLeads(Guid companyId, CancellationToken cancellationToken = default);
    public Task<LeadDtoResponse?> FindLeadById(Guid id, CancellationToken cancellationToken = default);
    public Task<LeadDtoResponse?> CreateLead(LeadCreateDtoServiceRequest lead, CancellationToken cancellationToken = default);
    public Task<LeadDtoResponse?> UpdateLead(LeadUpdateDtoServiceRequest lead, CancellationToken cancellationToken = default);
    public Task<bool> DeleteLead(Guid id, CancellationToken cancellationToken = default);
    public Task<LeadDtoResponse?> UpdateLeadPosition(Guid leadId, Guid companyPositionId, CancellationToken cancellationToken = default);
}