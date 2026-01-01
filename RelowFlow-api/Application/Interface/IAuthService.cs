using RelowFlow_api.Application.Dtos;

namespace RelowFlow_api.Application.Interface;

public interface IAuthService
{
    public Task<SigninRespnse> SignIn(SigninRequest req, CancellationToken cancellationToken = default); 
}