using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelowFlow_api.Domain.Entities.Lead;

namespace RelowFlow_api.Infrastructure.Persistence.Configurations;

public class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        // Nome da tabela
        builder.ToTable("leads");

        // Chave primária
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        // Propriedades
        builder.Property(l => l.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(l => l.CompanyId)
            .HasColumnName("company_id")
            .IsRequired();

        builder.Property(l => l.CompanyPositionId)
            .HasColumnName("company_position_id")
            .IsRequired();

        builder.Property(l => l.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(l => l.Description)
            .HasColumnName("description")
            .HasColumnType("text");

        builder.Property(l => l.Amount)
            .HasColumnName("amount")
            .HasColumnType("decimal(18,2)");

        builder.Property(l => l.Currency)
            .HasColumnName("currency")
            .HasMaxLength(10)
            .HasDefaultValue("EUR");

        // Endereço
        builder.Property(l => l.ZipCode)
            .HasColumnName("zip_code")
            .HasMaxLength(20);

        builder.Property(l => l.StreetAddress)
            .HasColumnName("street_address")
            .HasMaxLength(200);

        builder.Property(l => l.StreetAddressNumber)
            .HasColumnName("street_address_number")
            .HasMaxLength(20);

        builder.Property(l => l.StreetAddressComplement)
            .HasColumnName("street_address_complement")
            .HasMaxLength(200);

        builder.Property(l => l.City)
            .HasColumnName("city")
            .HasMaxLength(100);

        builder.Property(l => l.State)
            .HasColumnName("state")
            .HasMaxLength(100);

        builder.Property(l => l.Country)
            .HasColumnName("country")
            .HasMaxLength(100);

        // Propriedades de sistema
        builder.Property(l => l.Created)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(l => l.Updated)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(l => l.Deleted)
            .HasColumnName("deleted_at");

        // Relacionamentos
        // Lead -> Company (muitos para um)
        builder.HasOne(l => l.Company)
            .WithMany(c => c.Leads)
            .HasForeignKey(l => l.CompanyId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_leads_companies");

        // Lead -> CompanyPosition (muitos para um)
        builder.HasOne(l => l.CompanyPosition)
            .WithMany(cp => cp.Leads)
            .HasForeignKey(l => l.CompanyPositionId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_leads_company_positions");

        // Lead -> LeadMembers (um para muitos)
        builder.HasMany(l => l.Members)
            .WithOne(lm => lm.Lead)
            .HasForeignKey(lm => lm.LeadId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_leads_lead_members");

        // Índices
        builder.HasIndex(l => l.UserId)
            .HasDatabaseName("ix_leads_user_id");

        builder.HasIndex(l => l.CompanyId)
            .HasDatabaseName("ix_leads_company_id");

        builder.HasIndex(l => l.CompanyPositionId)
            .HasDatabaseName("ix_leads_company_position_id");

        builder.HasIndex(l => l.Deleted)
            .HasDatabaseName("ix_leads_deleted_at");
    }
}

