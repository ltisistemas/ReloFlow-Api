using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelowFlow_api.Domain.Entities.Lead;

namespace RelowFlow_api.Infrastructure.Persistence.Configurations;

public class LeadDocumentsConfiguration : IEntityTypeConfiguration<LeadDocuments>
{
    public void Configure(EntityTypeBuilder<LeadDocuments> builder)
    {
        // Nome da tabela
        builder.ToTable("lead_documents");

        // Chave primária
        builder.HasKey(ld => ld.Id);
        builder.Property(ld => ld.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        // Propriedades
        builder.Property(ld => ld.LeadId)
            .HasColumnName("lead_id")
            .IsRequired();

        builder.Property(ld => ld.LeadMemberId)
            .HasColumnName("lead_member_id");

        builder.Property(ld => ld.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(ld => ld.DocumentType)
            .HasColumnName("document_type")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(ld => ld.DocumentUrl)
            .HasColumnName("document_url")
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(ld => ld.State)
            .HasColumnName("state")
            .IsRequired()
            .HasConversion<int>()
            .HasDefaultValue(LeadDocumentState.PENDING);

        builder.Property(ld => ld.TargetType)
            .HasColumnName("target_type")
            .IsRequired()
            .HasConversion<int>()
            .HasDefaultValue(DocumentTargetType.LEAD);

        // Propriedades de sistema
        builder.Property(ld => ld.Created)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(ld => ld.Updated)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(ld => ld.Deleted)
            .HasColumnName("deleted_at");

        // Relacionamentos
        // LeadDocuments -> Lead (muitos para um)
        builder.HasOne(ld => ld.Lead)
            .WithMany()
            .HasForeignKey(ld => ld.LeadId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_lead_documents_leads");

        // LeadDocuments -> LeadMember (muitos para um, opcional)
        builder.HasOne(ld => ld.LeadMember)
            .WithMany()
            .HasForeignKey(ld => ld.LeadMemberId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_lead_documents_lead_members");

        // Índices
        builder.HasIndex(ld => ld.LeadId)
            .HasDatabaseName("ix_lead_documents_lead_id");

        builder.HasIndex(ld => ld.LeadMemberId)
            .HasDatabaseName("ix_lead_documents_lead_member_id");

        builder.HasIndex(ld => ld.Deleted)
            .HasDatabaseName("ix_lead_documents_deleted_at");
    }
}

