using UserEntity = RelowFlow_api.Domain.Entities.User.User;

namespace RelowFlow_api.Domain.Entities.Lead;

public class LeadMember
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid LeadId { get; set; } = Guid.Empty;
    public Guid? UserId { get; set; } = null;
    public string? Name { get; set; } = null;
    
    public DateTime Created { get; set; } = new DateTime();
    public DateTime Updated { get; set; } = new DateTime();
    public DateTime? Deleted { get; set; } = null;
    
    // Propriedades de navegação
    public virtual Lead? Lead { get; set; } = null;
    public virtual UserEntity? User { get; set; } = null;
}

