namespace RelowFlow_api.Domain.Entities.Lead;

public class LeadDocuments
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid LeadId { get; set; } = Guid.Empty;
    public Guid? LeadMemberId { get; set; } = null;
    public string Name { get; set; } = string.Empty;
    public string DocumentType { get; set; } = string.Empty;
    public string DocumentUrl { get; set; } = string.Empty;
    public LeadDocumentState State { get; set; } = LeadDocumentState.PENDING;
    public DocumentTargetType TargetType { get; set; } = DocumentTargetType.LEAD;
    
    public DateTime Created { get; set; } = new DateTime();
    public DateTime Updated { get; set; } = new DateTime();
    public DateTime? Deleted { get; set; } = null;
    
    // Propriedades de navegação
    public virtual Lead? Lead { get; set; } = null;
    public virtual LeadMember? LeadMember { get; set; } = null;
}