namespace RelowFlow_api.Application.Dtos;

public record SignupRequest(string FirstName, string LastName, string Email, string Password);

public record SigninRequest(string Email, string Password);

public record SigninRespnse(
    string Token,
    Guid Sub,
    string Email,
    string Name
);