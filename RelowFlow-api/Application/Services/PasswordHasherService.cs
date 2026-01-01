using RelowFlow_api.Application.Interface;

namespace RelowFlow_api.Application.Services;

public class PasswordHasherService: ICryptHasherService
{
    private const int DefaultSaltRounds = 12;
    
    public string Hash(string value, int saltRounds = DefaultSaltRounds)
    {
        return BCrypt.Net.BCrypt.HashPassword(value, BCrypt.Net.BCrypt.GenerateSalt(saltRounds));
    }

    public bool Verify(string valueAttempt, string hashedValue)
    {
        return BCrypt.Net.BCrypt.Verify(valueAttempt, hashedValue);
    }
}

