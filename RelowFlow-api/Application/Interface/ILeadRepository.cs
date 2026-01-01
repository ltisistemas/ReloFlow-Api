using RelowFlow_api.Domain.Entities.Lead;

namespace RelowFlow_api.Application.Interface;

public interface ILeadRepository
{
    public Task<IEnumerable<Lead>> FindAllLeads(Guid companyId, CancellationToken cancellationToken = default);
    public Task<Lead?> FindLeadById(Guid id, CancellationToken cancellationToken = default);
    public Task<Lead> CreateLead(Lead lead, CancellationToken cancellationToken = default);
    public Task<Lead> UpdateLead(Lead lead, CancellationToken cancellationToken = default);
    public Task<bool> DeleteLead(Lead lead, CancellationToken cancellationToken = default);
}