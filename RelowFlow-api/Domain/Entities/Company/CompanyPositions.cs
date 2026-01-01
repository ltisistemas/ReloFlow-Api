using LeadEntity = RelowFlow_api.Domain.Entities.Lead.Lead;

namespace RelowFlow_api.Domain.Entities.Company;

public class CompanyPositions
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CompanyId { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    
    public DateTime Created { get; set; } = new DateTime();
    public DateTime Updated { get; set; } = new DateTime();
    public DateTime? Deleted { get; set; } = null;
    
    public virtual Company? Company { get; set; } = null;
    public virtual ICollection<LeadEntity> Leads { get; set; } = new List<LeadEntity>();
    public virtual ICollection<CompanyPositionDocumentTemplate> DocumentTemplates { get; set; } = new List<CompanyPositionDocumentTemplate>();
}