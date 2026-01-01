using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelowFlow_api.Domain.Entities.Company;

namespace RelowFlow_api.Infrastructure.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        // Nome da tabela
        builder.ToTable("companies");

        // Chave primária
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        // Propriedades
        builder.Property(c => c.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(c => c.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Description)
            .HasColumnName("description")
            .HasColumnType("text");

        builder.Property(c => c.FinancialCode)
            .HasColumnName("financial_code")
            .IsRequired()
            .HasMaxLength(50);

        // Propriedades de sistema
        builder.Property(c => c.Created)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(c => c.Updated)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(c => c.Deleted)
            .HasColumnName("deleted_at");

        // Relacionamentos
        // Company -> CompanyPositions (um para muitos)
        builder.HasMany(c => c.Positions)
            .WithOne(p => p.Company)
            .HasForeignKey(p => p.CompanyId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_companies_company_positions");

        // Company -> Leads (um para muitos)
        builder.HasMany(c => c.Leads)
            .WithOne(l => l.Company)
            .HasForeignKey(l => l.CompanyId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_companies_leads");

        // Company -> CompanyUsers (um para muitos)
        builder.HasMany(c => c.Users)
            .WithOne(cu => cu.Company)
            .HasForeignKey(cu => cu.CompanyId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_companies_company_users");

        // Índices
        builder.HasIndex(c => c.UserId)
            .HasDatabaseName("ix_companies_user_id");

        builder.HasIndex(c => c.FinancialCode)
            .IsUnique()
            .HasDatabaseName("ix_companies_financial_code");

        builder.HasIndex(c => c.Deleted)
            .HasDatabaseName("ix_companies_deleted_at");
    }
}

