using RelowFlow_api.Application.Dtos;

namespace RelowFlow_api.Application.Interface;

public interface ICompanyUserService
{
    Task<IEnumerable<CompanyUserDtoResponse>> FindAllCompanyUsers(Guid companyId, CancellationToken cancellationToken = default);
    Task<CompanyUserDtoResponse?> FindCompanyUserById(Guid id, CancellationToken cancellationToken = default);
    Task<CompanyUserDtoResponse?> CreateCompanyUser(CompanyUserCreateDtoServiceRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteCompanyUser(Guid id, CancellationToken cancellationToken = default);
}

