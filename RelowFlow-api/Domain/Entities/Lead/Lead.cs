using CompanyEntity = RelowFlow_api.Domain.Entities.Company.Company;
using CompanyPositionsEntity = RelowFlow_api.Domain.Entities.Company.CompanyPositions;

namespace RelowFlow_api.Domain.Entities.Lead;

public class Lead
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } =  Guid.Empty;
    public Guid CompanyId { get; set; } =  Guid.Empty;
    public Guid CompanyPositionId { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal? Amount { get; set; } = null;
    public string Currency { get; set; } = string.Empty;
    public string? ZipCode { get; set; } = string.Empty;
    public string? StreetAddress { get; set; } = string.Empty;
    public string? StreetAddressNumber { get; set; } = string.Empty;
    public string? StreetAddressComplement { get; set; } = string.Empty;
    public string? City { get; set; } = string.Empty;
    public string? State { get; set; } = string.Empty;
    public string? Country { get; set; } = string.Empty;
    
    public DateTime Created { get; set; } = new DateTime();
    public DateTime Updated { get; set; } = new DateTime();
    public DateTime? Deleted { get; set; } = null;
    
    // Propriedades de navegação
    public virtual CompanyEntity? Company { get; set; } = null;
    public virtual CompanyPositionsEntity? CompanyPosition { get; set; } = null;
    public virtual ICollection<LeadMember> Members { get; set; } = new List<LeadMember>();
}