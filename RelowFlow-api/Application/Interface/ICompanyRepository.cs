using RelowFlow_api.Domain.Entities.Company;

namespace RelowFlow_api.Application.Interface;

public interface ICompanyRepository
{
    public Task<IEnumerable<Company>> FindAllCompanys(Guid userId, CancellationToken cancellationToken = default);
    public Task<Company?> FindCompanyById(Guid id, CancellationToken cancellationToken = default);
    
    public Task<Company> CreateCompany(Company company, CancellationToken cancellationToken = default);
}