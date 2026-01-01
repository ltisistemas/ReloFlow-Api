using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelowFlow_api.Domain.Entities.Company;

namespace RelowFlow_api.Infrastructure.Persistence.Configurations;

public class CompanyPositionsConfiguration : IEntityTypeConfiguration<CompanyPositions>
{
    public void Configure(EntityTypeBuilder<CompanyPositions> builder)
    {
        // Nome da tabela
        builder.ToTable("company_positions");

        // Chave primária
        builder.HasKey(cp => cp.Id);
        builder.Property(cp => cp.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        // Propriedades
        builder.Property(cp => cp.CompanyId)
            .HasColumnName("company_id")
            .IsRequired();

        builder.Property(cp => cp.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        // Propriedades de sistema
        builder.Property(cp => cp.Created)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(cp => cp.Updated)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(cp => cp.Deleted)
            .HasColumnName("deleted_at");

        // Relacionamentos
        // CompanyPositions -> Company (muitos para um)
        builder.HasOne(cp => cp.Company)
            .WithMany(c => c.Positions)
            .HasForeignKey(cp => cp.CompanyId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_company_positions_companies");

        // CompanyPositions -> Leads (um para muitos)
        builder.HasMany(cp => cp.Leads)
            .WithOne(l => l.CompanyPosition)
            .HasForeignKey(l => l.CompanyPositionId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_company_positions_leads");

        // CompanyPositions -> DocumentTemplates (um para muitos)
        builder.HasMany(cp => cp.DocumentTemplates)
            .WithOne(t => t.CompanyPosition)
            .HasForeignKey(t => t.CompanyPositionId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_company_positions_document_templates");

        // Índices
        builder.HasIndex(cp => cp.CompanyId)
            .HasDatabaseName("ix_company_positions_company_id");

        builder.HasIndex(cp => cp.Deleted)
            .HasDatabaseName("ix_company_positions_deleted_at");
    }
}

