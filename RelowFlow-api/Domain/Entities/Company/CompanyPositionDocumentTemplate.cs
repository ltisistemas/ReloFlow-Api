using RelowFlow_api.Domain.Entities.Lead;

namespace RelowFlow_api.Domain.Entities.Company;

public class CompanyPositionDocumentTemplate
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CompanyPositionId { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string DocumentType { get; set; } = string.Empty;
    public bool IsRequired { get; set; } = false;
    public DocumentTargetType TargetType { get; set; } = DocumentTargetType.LEAD;
    
    public DateTime Created { get; set; } = new DateTime();
    public DateTime Updated { get; set; } = new DateTime();
    public DateTime? Deleted { get; set; } = null;
    
    // Propriedade de navegação
    public virtual CompanyPositions? CompanyPosition { get; set; } = null;
}

