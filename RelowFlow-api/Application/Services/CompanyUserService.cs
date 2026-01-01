using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.Company;

namespace RelowFlow_api.Application.Services;

public class CompanyUserService(ICompanyUserRepository repository) : ICompanyUserService
{
    public async Task<IEnumerable<CompanyUserDtoResponse>> FindAllCompanyUsers(Guid companyId, CancellationToken cancellationToken = default)
    {
        var entities = await repository.FindAllCompanyUsers(companyId, cancellationToken);
        return entities.Select(MapToDto).Where(dto => dto != null)!;
    }

    public async Task<CompanyUserDtoResponse?> FindCompanyUserById(Guid id, CancellationToken cancellationToken = default)
    {
        return MapToDto(await repository.FindCompanyUserById(id, cancellationToken));
    }

    public async Task<CompanyUserDtoResponse?> CreateCompanyUser(CompanyUserCreateDtoServiceRequest request, CancellationToken cancellationToken = default)
    {
        var entity = new CompanyUser
        {
            CompanyId = request.CompanyId,
            UserId = request.UserId
        };

        return MapToDto(await repository.CreateCompanyUser(entity, cancellationToken));
    }

    public async Task<bool> DeleteCompanyUser(Guid id, CancellationToken cancellationToken = default)
    {
        var existing = await repository.FindCompanyUserById(id, cancellationToken);
        
        if (existing == null)
        {
            throw new Exception($"Company User with Id {id} not found");
        }

        return await repository.DeleteCompanyUser(existing, cancellationToken);
    }

    private CompanyUserDtoResponse? MapToDto(CompanyUser? companyUser)
    {
        if (companyUser != null)
            return new CompanyUserDtoResponse(
                companyUser.Id,
                companyUser.CompanyId,
                companyUser.UserId,
                companyUser.Created,
                companyUser.Updated,
                companyUser.Deleted
            );

        return null;
    }
}

