using Microsoft.EntityFrameworkCore;
using RelowFlow_api.Domain.Entities.Company;
using RelowFlow_api.Domain.Entities.Lead;
using RelowFlow_api.Domain.Entities.User;
using RelowFlow_api.Infrastructure.Persistence.Configurations;

namespace RelowFlow_api.Infrastructure.Persistence;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Tudo começa no Usuário
    public DbSet<User> Users { get; set; }
    
    // Caso o usuário se torne um Relocation, precisa ter uma empresa
    public DbSet<Company> Companys { get; set; }
    
    // Colunas do Kanban
    public DbSet<CompanyPositions> CompanyPositions { get; set; }
    
    public DbSet<Lead> Leads { get; set; }
    
    public DbSet<LeadDocuments> LeadDocuments { get; set; }
    
    public DbSet<LeadMember> LeadMembers { get; set; }
    
    public DbSet<CompanyUser> CompanyUsers { get; set; }
    
    public DbSet<CompanyPositionDocumentTemplate> CompanyPositionDocumentTemplates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplicar todas as configurações de persistência
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            
        base.OnModelCreating(modelBuilder);
    }
}