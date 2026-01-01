using UserEntity = RelowFlow_api.Domain.Entities.User.User;

namespace RelowFlow_api.Domain.Entities.Company;

public class CompanyUser
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CompanyId { get; set; } = Guid.Empty;
    public Guid UserId { get; set; } = Guid.Empty;
    
    public DateTime Created { get; set; } = new DateTime();
    public DateTime Updated { get; set; } = new DateTime();
    public DateTime? Deleted { get; set; } = null;
    
    // Propriedades de navegação
    public virtual Company? Company { get; set; } = null;
    public virtual UserEntity? User { get; set; } = null;
}

