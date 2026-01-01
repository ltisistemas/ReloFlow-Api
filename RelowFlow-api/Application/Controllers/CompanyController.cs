using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Exceptions;
using RelowFlow_api.Application.Helper;
using RelowFlow_api.Application.Interface;
using RelowFlow_api.Domain.Entities.Company;

namespace RelowFlow_api.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController(ICompanyService service): ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> FindAll(CancellationToken cancellationToken = default)
    {
        var userId = JwtHelper.GetUserId(this.HttpContext);
        var entities = await service.FindAllCompanys(userId, cancellationToken);
        return this.OkResponse(entities);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CompanyCreateDtoRequest req, CancellationToken cancellationToken = default)
    {
        var userId = JwtHelper.GetUserId(this.HttpContext);
        req = req with { UserId = userId };
        return this.CreatedResponse(await service.CreateCompany(req, cancellationToken));
    }
}