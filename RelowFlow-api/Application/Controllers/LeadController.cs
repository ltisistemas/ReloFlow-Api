using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Helper;
using RelowFlow_api.Application.Interface;

namespace RelowFlow_api.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class  LeadController(ILeadService service): ControllerBase
{
    [HttpGet("company/{companyId}")]
    [Authorize]
    public async Task<IActionResult> FindAll(Guid companyId, CancellationToken cancellationToken = default)
    {
        var entities = await service.FindAllLeads(companyId, cancellationToken);
        return this.OkResponse(entities);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> FindById(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await service.FindLeadById(id, cancellationToken);
        if (entity == null)
        {
            return this.ErrorResponse("Lead not found", 404);
        }
        return this.OkResponse(entity);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(LeadCreateDtoRequest req, CancellationToken cancellationToken = default)
    {
        var userId = JwtHelper.GetUserId(this.HttpContext);
        var dto = new LeadCreateDtoServiceRequest(
            userId,
            req.CompanyId,
            req.CompanyPositionId,
            req.Name,
            req.Description
        );
        
        return this.CreatedResponse(await service.CreateLead(dto, cancellationToken));
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, LeadUpdateDtoRequest req, CancellationToken cancellationToken = default)
    {
        var dto = new LeadUpdateDtoServiceRequest(
            id,
            req.Name,
            req.Description,
            req.Amount,
            req.Currency,
            req.ZipCode,
            req.StreetAddress,
            req.StreetAddressNumber,
            req.StreetAddressComplement,
            req.City,
            req.State,
            req.Country,
            req.CompanyId,
            req.CompanyPositionId
        );
        
        var result = await service.UpdateLead(dto, cancellationToken);
        return this.OkResponse(result);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await service.DeleteLead(id, cancellationToken);
        return this.OkResponse(new { success = result });
    }

    [HttpPatch("{id}/position")]
    [Authorize]
    public async Task<IActionResult> UpdatePosition(Guid id, LeadUpdatePositionDtoRequest req, CancellationToken cancellationToken = default)
    {
        var result = await service.UpdateLeadPosition(id, req.CompanyPositionId, cancellationToken);
        return this.OkResponse(result);
    }
}