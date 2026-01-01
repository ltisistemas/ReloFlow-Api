using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Helper;
using RelowFlow_api.Application.Interface;

namespace RelowFlow_api.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadMemberController(ILeadMemberService service) : ControllerBase
{
    [HttpGet("lead/{leadId}")]
    [Authorize]
    public async Task<IActionResult> FindAll(Guid leadId, CancellationToken cancellationToken = default)
    {
        var entities = await service.FindAllLeadMembers(leadId, cancellationToken);
        return this.OkResponse(entities);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> FindById(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await service.FindLeadMemberById(id, cancellationToken);
        if (entity == null)
        {
            return this.ErrorResponse("Lead Member not found", 404);
        }
        return this.OkResponse(entity);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(LeadMemberCreateDtoRequest req, CancellationToken cancellationToken = default)
    {
        var dto = new LeadMemberCreateDtoServiceRequest(
            req.LeadId,
            req.UserId,
            req.Name
        );
        
        return this.CreatedResponse(await service.CreateLeadMember(dto, cancellationToken));
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, LeadMemberUpdateDtoRequest req, CancellationToken cancellationToken = default)
    {
        var dto = new LeadMemberUpdateDtoServiceRequest(
            id,
            req.UserId,
            req.Name
        );
        
        var result = await service.UpdateLeadMember(dto, cancellationToken);
        return this.OkResponse(result);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await service.DeleteLeadMember(id, cancellationToken);
        return this.OkResponse(new { success = result });
    }
}

