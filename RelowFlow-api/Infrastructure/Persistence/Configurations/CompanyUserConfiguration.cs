using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelowFlow_api.Domain.Entities.Company;

namespace RelowFlow_api.Infrastructure.Persistence.Configurations;

public class CompanyUserConfiguration : IEntityTypeConfiguration<CompanyUser>
{
    public void Configure(EntityTypeBuilder<CompanyUser> builder)
    {
        // Nome da tabela
        builder.ToTable("company_users");

        // Chave primária
        builder.HasKey(cu => cu.Id);
        builder.Property(cu => cu.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        // Propriedades
        builder.Property(cu => cu.CompanyId)
            .HasColumnName("company_id")
            .IsRequired();

        builder.Property(cu => cu.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        // Propriedades de sistema
        builder.Property(cu => cu.Created)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(cu => cu.Updated)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(cu => cu.Deleted)
            .HasColumnName("deleted_at");

        // Relacionamentos
        // CompanyUser -> Company (muitos para um)
        builder.HasOne(cu => cu.Company)
            .WithMany(c => c.Users)
            .HasForeignKey(cu => cu.CompanyId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_company_users_companies");

        // CompanyUser -> User (muitos para um)
        builder.HasOne(cu => cu.User)
            .WithMany()
            .HasForeignKey(cu => cu.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_company_users_users");

        // Índices
        builder.HasIndex(cu => cu.CompanyId)
            .HasDatabaseName("ix_company_users_company_id");

        builder.HasIndex(cu => cu.UserId)
            .HasDatabaseName("ix_company_users_user_id");

        // Índice único para evitar duplicatas (um usuário não pode estar na mesma empresa duas vezes)
        builder.HasIndex(cu => new { cu.CompanyId, cu.UserId })
            .IsUnique()
            .HasDatabaseName("ix_company_users_company_user_unique")
            .HasFilter("\"deleted_at\" IS NULL");

        builder.HasIndex(cu => cu.Deleted)
            .HasDatabaseName("ix_company_users_deleted_at");
    }
}

