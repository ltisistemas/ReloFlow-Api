namespace RelowFlow_api.Application.Interface;

public interface ICryptHasherService
{
    public string Hash(string value, int saltRounds = 12);

    public bool Verify(string valueAttempt, string hashedValue);
}