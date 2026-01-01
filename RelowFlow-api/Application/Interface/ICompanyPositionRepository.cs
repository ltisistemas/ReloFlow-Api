using RelowFlow_api.Domain.Entities.Company;

namespace RelowFlow_api.Application.Interface;

public interface ICompanyPositionRepository
{
    public Task<IEnumerable<CompanyPositions>> FindAllCompanyPositions(CancellationToken cancellationToken = default);
    public Task<CompanyPositions?> FindCompanyPositionsById(Guid id, CancellationToken cancellationToken = default);
    public Task<IEnumerable<CompanyPositions>> FindCompanyPositionsByCompanyId(Guid companyId, CancellationToken cancellationToken = default);
}