using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Helper;
using RelowFlow_api.Application.Interface;

namespace RelowFlow_api.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyUserController(ICompanyUserService service) : ControllerBase
{
    [HttpGet("company/{companyId}")]
    [Authorize]
    public async Task<IActionResult> FindAll(Guid companyId, CancellationToken cancellationToken = default)
    {
        var entities = await service.FindAllCompanyUsers(companyId, cancellationToken);
        return this.OkResponse(entities);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> FindById(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await service.FindCompanyUserById(id, cancellationToken);
        if (entity == null)
        {
            return this.ErrorResponse("Company User not found", 404);
        }
        return this.OkResponse(entity);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CompanyUserCreateDtoRequest req, CancellationToken cancellationToken = default)
    {
        var dto = new CompanyUserCreateDtoServiceRequest(
            req.CompanyId,
            req.UserId
        );
        
        return this.CreatedResponse(await service.CreateCompanyUser(dto, cancellationToken));
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await service.DeleteCompanyUser(id, cancellationToken);
        return this.OkResponse(new { success = result });
    }
}

