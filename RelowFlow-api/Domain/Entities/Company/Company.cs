using LeadEntity = RelowFlow_api.Domain.Entities.Lead.Lead;

namespace RelowFlow_api.Domain.Entities.Company;

public class Company
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } =  Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string FinancialCode { get; set; } = string.Empty;
    
    public DateTime Created { get; set; } = new DateTime();
    public DateTime Updated { get; set; } = new DateTime();
    public DateTime? Deleted { get; set; } = null;
    
    // Propriedades de navegação
    public virtual ICollection<CompanyPositions> Positions { get; set; } = new List<CompanyPositions>();
    public virtual ICollection<LeadEntity> Leads { get; set; } = new List<LeadEntity>();
    public virtual ICollection<CompanyUser> Users { get; set; } = new List<CompanyUser>();
}