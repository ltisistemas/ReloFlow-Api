using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelowFlow_api.Domain.Entities.Lead;

namespace RelowFlow_api.Infrastructure.Persistence.Configurations;

public class LeadMemberConfiguration : IEntityTypeConfiguration<LeadMember>
{
    public void Configure(EntityTypeBuilder<LeadMember> builder)
    {
        // Nome da tabela
        builder.ToTable("lead_members");

        // Chave primária
        builder.HasKey(lm => lm.Id);
        builder.Property(lm => lm.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        // Propriedades
        builder.Property(lm => lm.LeadId)
            .HasColumnName("lead_id")
            .IsRequired();

        builder.Property(lm => lm.UserId)
            .HasColumnName("user_id");

        builder.Property(lm => lm.Name)
            .HasColumnName("name")
            .HasMaxLength(200);

        // Propriedades de sistema
        builder.Property(lm => lm.Created)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(lm => lm.Updated)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(lm => lm.Deleted)
            .HasColumnName("deleted_at");

        // Relacionamentos
        // LeadMember -> Lead (muitos para um)
        builder.HasOne(lm => lm.Lead)
            .WithMany(l => l.Members)
            .HasForeignKey(lm => lm.LeadId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_lead_members_leads");

        // LeadMember -> User (muitos para um, opcional)
        builder.HasOne(lm => lm.User)
            .WithMany()
            .HasForeignKey(lm => lm.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_lead_members_users");

        // Índices
        builder.HasIndex(lm => lm.LeadId)
            .HasDatabaseName("ix_lead_members_lead_id");

        builder.HasIndex(lm => lm.UserId)
            .HasDatabaseName("ix_lead_members_user_id");

        builder.HasIndex(lm => lm.Deleted)
            .HasDatabaseName("ix_lead_members_deleted_at");
    }
}

