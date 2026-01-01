using RelowFlow_api.Domain.Entities.Company;

namespace RelowFlow_api.Application.Interface;

public interface ICompanyUserRepository
{
    Task<IEnumerable<CompanyUser>> FindAllCompanyUsers(Guid companyId, CancellationToken cancellationToken = default);
    Task<CompanyUser?> FindCompanyUserById(Guid id, CancellationToken cancellationToken = default);
    Task<CompanyUser?> FindCompanyUserByCompanyAndUser(Guid companyId, Guid userId, CancellationToken cancellationToken = default);
    Task<CompanyUser> CreateCompanyUser(CompanyUser companyUser, CancellationToken cancellationToken = default);
    Task<bool> DeleteCompanyUser(CompanyUser companyUser, CancellationToken cancellationToken = default);
}

