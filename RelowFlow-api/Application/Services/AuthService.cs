using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Exceptions;
using RelowFlow_api.Application.Helper;
using RelowFlow_api.Application.Interface;

namespace RelowFlow_api.Application.Services;

public class AuthService(IUserRepository repository, ICryptHasherService hasherService, JwtService jwtService): IAuthService
{
    public async Task<SigninRespnse> SignIn(SigninRequest req, CancellationToken cancellationToken = default)
    {
        var user = await repository.FindUserByEmail(req.Email, cancellationToken);
        if (user == null)
        {
            throw new EmailNotFoundException(req.Email);
        }

        if (!hasherService.Verify(req.Password, user.Password))
        {
            throw new UserOrPasswordNotFoundException();
        }

        // Atualizar último login
        await repository.SetUserLastLogin(user.Id, DateTime.UtcNow, cancellationToken);

        var token = jwtService.GenerateToken(user);
        var fullName = string.Concat(user.FirstName, " ", user.LastName);
    
        return new SigninRespnse(token, user.Id, user.Email, fullName);
    }
}