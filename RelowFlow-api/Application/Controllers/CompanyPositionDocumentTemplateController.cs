using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RelowFlow_api.Application.Dtos;
using RelowFlow_api.Application.Helper;
using RelowFlow_api.Application.Interface;

namespace RelowFlow_api.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyPositionDocumentTemplateController(ICompanyPositionDocumentTemplateService service) : ControllerBase
{
    [HttpGet("company-position/{companyPositionId}")]
    [Authorize]
    public async Task<IActionResult> FindAll(Guid companyPositionId, CancellationToken cancellationToken = default)
    {
        var entities = await service.FindAllDocumentTemplates(companyPositionId, cancellationToken);
        return this.OkResponse(entities);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> FindById(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await service.FindDocumentTemplateById(id, cancellationToken);
        if (entity == null)
        {
            return this.ErrorResponse("Document Template not found", 404);
        }
        return this.OkResponse(entity);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CompanyPositionDocumentTemplateCreateDtoRequest req, CancellationToken cancellationToken = default)
    {
        var dto = new CompanyPositionDocumentTemplateCreateDtoServiceRequest(
            req.CompanyPositionId,
            req.Name,
            req.DocumentType,
            req.IsRequired,
            req.TargetType
        );
        
        return this.CreatedResponse(await service.CreateDocumentTemplate(dto, cancellationToken));
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, CompanyPositionDocumentTemplateUpdateDtoRequest req, CancellationToken cancellationToken = default)
    {
        var dto = new CompanyPositionDocumentTemplateUpdateDtoServiceRequest(
            id,
            req.Name,
            req.DocumentType,
            req.IsRequired,
            req.TargetType
        );
        
        var result = await service.UpdateDocumentTemplate(dto, cancellationToken);
        return this.OkResponse(result);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await service.DeleteDocumentTemplate(id, cancellationToken);
        return this.OkResponse(new { success = result });
    }
}

