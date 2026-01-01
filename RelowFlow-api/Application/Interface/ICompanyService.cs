using RelowFlow_api.Application.Dtos;

namespace RelowFlow_api.Application.Interface;

public interface ICompanyService
{
    public Task<IEnumerable<CompanyDtoResponse>> FindAllCompanys(Guid userId, CancellationToken cancellationToken = default);
    public Task<CompanyDtoResponse?> FindCompanyById(Guid id, CancellationToken cancellationToken = default);
    
    public Task<CompanyDtoResponse?> CreateCompany(CompanyCreateDtoRequest company, CancellationToken cancellationToken = default);
}