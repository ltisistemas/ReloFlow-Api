using Microsoft.EntityFrameworkCore;
using RelowFlow_api.Application.Exceptions;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.User;
using RelowFlow_api.Infrastructure.Persistence;

namespace RelowFlow_api.Infrastructure.Repositories;

public class UserRepository(AppDbContext context): IUserRepository
{
    public async Task<IEnumerable<User>> FindAllUsers(
        CancellationToken cancellationToken = default)
    {
        return await context.Users
            .AsNoTracking()
            .Where(u => u.Deleted == null)
            .ToListAsync(cancellationToken);
    }

    public Task<User?> FindUserById(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> FindUserByEmail(
        string email, 
        CancellationToken cancellationToken = default)
    {
        return await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.Email == email 
                     && x.Status == UserStatusEnum.ACTIVE 
                     && x.Deleted == null, 
                cancellationToken);
    }

    public async Task<User> CreateUser(
        User user, 
        CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public Task<User> UpdateUser(User user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUser(User user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<User> ChangeUserPassword(string password, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<User> ChangeUserStatus(UserStatusEnum status, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User> SetUserLastLogin(Guid userId, DateTime lastLogin, CancellationToken cancellationToken = default)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
    
        if (user == null)
        {
            throw new UserNotFoundException(userId);
        }

        user.LastLogin = lastLogin;
        await context.SaveChangesAsync(cancellationToken);
    
        return user;
    }
}