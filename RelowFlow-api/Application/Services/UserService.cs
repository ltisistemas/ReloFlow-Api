using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Exceptions;
using RelowFlow_api.Application.Helper;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.User;

namespace RelowFlow_api.Application.Services;

public class UserService(IUserRepository repository, ICryptHasherService hasherService) : IUserService
{
    public async Task<IEnumerable<UserDtoResponse?>> FindAllUsers(CancellationToken cancellationToken = default)
    {
        var entities = await repository.FindAllUsers(cancellationToken);
        
        return entities.Select(MapToDto);
    }

    public async Task<UserDtoResponse?> FindUserByEmail(string email, CancellationToken cancellationToken = default)
    {
        return MapToDto(await repository.FindUserByEmail(email, cancellationToken));
    }

    public async Task<UserDtoResponse?> CreateUser(User user, CancellationToken cancellationToken = default)
    {
        var checkEmail = await repository.FindUserByEmail(user.Email, cancellationToken);
        if (checkEmail != null)
        {
            throw new EmailExistsException(user.Email);
        }

        // Timestamps serão setados automaticamente pelo AuditInterceptor
        var password = hasherService.Hash(user.Password);
        user.Password = password;
    
        return MapToDto(await repository.CreateUser(user, cancellationToken));
    }
    private UserDtoResponse? MapToDto(User? user)
    {
        if (user != null)
            return new UserDtoResponse(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.Gender ?? GenderEnum.OTHER,
                user.Nif ?? string.Empty,
                user.Niss ?? string.Empty,
                user.RegisterNumber ?? string.Empty,
                user.Nacionalidad ?? string.Empty,
                user.Naturalidad ?? string.Empty,
                user.Profession ?? string.Empty,
                user.Salary,
                user.ZipCode ?? string.Empty,
                user.StreetAddress ?? string.Empty,
                user.StreetAddressNumber ?? string.Empty,
                user.StreetAddressComplement ?? string.Empty,
                user.City ?? string.Empty,
                user.State ?? string.Empty,
                user.Country ?? string.Empty,
                user.PassportNumber ?? string.Empty,
                user.PassportCreated ?? DateOnly.MinValue,
                user.PassportExpires ?? DateOnly.MinValue,
                user.HasVisa,
                user.VisaStartDate ?? DateOnly.MinValue,
                user.VisaEndDate ?? DateOnly.MinValue,
                user.AnotherInformation ?? string.Empty,
                user.ResetPassword,
                user.LastLogin,
                user.Status,
                user.Created,
                user.Updated
            );

        return null;
    }
}