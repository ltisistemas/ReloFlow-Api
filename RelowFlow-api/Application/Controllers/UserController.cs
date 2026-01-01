using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RelowFlow_api.Application.Helper;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.User;

namespace RelowFlow_api.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService service): ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> FindAll(CancellationToken cancellationToken = default)
    {
        var entities = await service.FindAllUsers(cancellationToken);
        return this.OkResponse(entities);
    }
}