using RelowFlow_api.Domain.Entities.User;

namespace RelowFlow_api.Application.Interface;

public interface IUserRepository
{
    public Task<IEnumerable<User>> FindAllUsers(CancellationToken cancellationToken = default);
    public Task<User?> FindUserById(CancellationToken cancellationToken = default);
    public Task<User?> FindUserByEmail(string email, CancellationToken cancellationToken = default);
    
    public Task<User> CreateUser(User user, CancellationToken cancellationToken = default);
    public Task<User> UpdateUser(User user, CancellationToken cancellationToken = default);
    public Task<bool> DeleteUser(User user, CancellationToken cancellationToken = default);
    
    public Task<User> ChangeUserPassword(string password, CancellationToken cancellationToken = default);
    public Task<User> ChangeUserStatus(UserStatusEnum status,CancellationToken  cancellationToken = default);
    Task<User> SetUserLastLogin(Guid userId, DateTime lastLogin, CancellationToken cancellationToken = default);
}