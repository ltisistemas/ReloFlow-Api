using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Domain.Entities.User;

namespace RelowFlow_api.Application.Interface;

public interface IUserService
{
    public Task<IEnumerable<UserDtoResponse?>> FindAllUsers(CancellationToken cancellationToken = default);
    public Task<UserDtoResponse?> FindUserByEmail(string email, CancellationToken cancellationToken = default);
    
    public Task<UserDtoResponse?> CreateUser(User user, CancellationToken cancellationToken = default);
}