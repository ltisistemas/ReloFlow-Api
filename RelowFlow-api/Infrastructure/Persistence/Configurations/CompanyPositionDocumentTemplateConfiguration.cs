using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelowFlow_api.Domain.Entities.Company;

namespace RelowFlow_api.Infrastructure.Persistence.Configurations;

public class CompanyPositionDocumentTemplateConfiguration : IEntityTypeConfiguration<CompanyPositionDocumentTemplate>
{
    public void Configure(EntityTypeBuilder<CompanyPositionDocumentTemplate> builder)
    {
        // Nome da tabela
        builder.ToTable("company_position_document_templates");

        // Chave primária
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        // Propriedades
        builder.Property(t => t.CompanyPositionId)
            .HasColumnName("company_position_id")
            .IsRequired();

        builder.Property(t => t.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.DocumentType)
            .HasColumnName("document_type")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.IsRequired)
            .HasColumnName("is_required")
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(t => t.TargetType)
            .HasColumnName("target_type")
            .IsRequired()
            .HasConversion<int>()
            .HasDefaultValue(Domain.Entities.Lead.DocumentTargetType.LEAD);

        // Propriedades de sistema
        builder.Property(t => t.Created)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(t => t.Updated)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(t => t.Deleted)
            .HasColumnName("deleted_at");

        // Relacionamentos
        // CompanyPositionDocumentTemplate -> CompanyPositions (muitos para um)
        builder.HasOne(t => t.CompanyPosition)
            .WithMany(cp => cp.DocumentTemplates)
            .HasForeignKey(t => t.CompanyPositionId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_company_position_document_templates_company_positions");

        // Índices
        builder.HasIndex(t => t.CompanyPositionId)
            .HasDatabaseName("ix_company_position_document_templates_company_position_id");

        builder.HasIndex(t => t.Deleted)
            .HasDatabaseName("ix_company_position_document_templates_deleted_at");
    }
}

