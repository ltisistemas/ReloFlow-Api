using Microsoft.AspNetCore.Mvc;
using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Helper;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Application.Services;
using RelowFlow_api.Domain.Entities.User;

namespace RelowFlow_api.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IUserService userService, IAuthService service) : ControllerBase
{
    /// <summary>
    /// Realiza login do usuário
    /// </summary>
    /// <param name="req">Dados de login. Exemplo: {"email": "luizdantasdesign@gmail.com", "password": "sEnha004"}</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Token JWT e informações do usuário</returns>
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(SigninRequest req, CancellationToken cancellationToken = default)
    {
        // Validação automática via FluentValidation.AutoValidation
        return this.OkResponse(await service.SignIn(req, cancellationToken));
    }
    
    [HttpPost("signup")]
    public async Task<IActionResult> SingUp(SignupRequest req, CancellationToken cancellationToken = default)
    {
        // Validação automática via FluentValidation.AutoValidation
        var user = new User
        {
            FirstName = req.FirstName.Trim(),
            LastName = req.LastName.Trim(),
            Email = req.Email.Trim().ToLowerInvariant(),
            Password = req.Password
        };

        return this.CreatedResponse(await userService.CreateUser(user, cancellationToken));
    }
}