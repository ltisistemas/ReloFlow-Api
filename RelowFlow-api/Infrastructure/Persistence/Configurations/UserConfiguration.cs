using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelowFlow_api.Domain.Entities.User;

namespace RelowFlow_api.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Nome da tabela
        builder.ToTable("users");

        // Chave primária
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        // Propriedades básicas
        builder.Property(u => u.FirstName)
            .HasColumnName("first_name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.LastName)
            .HasColumnName("last_name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Password)
            .HasColumnName("password")
            .IsRequired()
            .HasMaxLength(500);

        // Propriedades opcionais
        builder.Property(u => u.Gender)
            .HasColumnName("gender")
            .HasConversion<int>();

        builder.Property(u => u.Nif)
            .HasColumnName("nif")
            .HasMaxLength(20);

        builder.Property(u => u.Niss)
            .HasColumnName("niss")
            .HasMaxLength(20);

        builder.Property(u => u.RegisterNumber)
            .HasColumnName("register_number")
            .HasMaxLength(50);

        builder.Property(u => u.Nacionalidad)
            .HasColumnName("nacionalidad")
            .HasMaxLength(100);

        builder.Property(u => u.Naturalidad)
            .HasColumnName("naturalidad")
            .HasMaxLength(100);

        builder.Property(u => u.Profession)
            .HasColumnName("profession")
            .HasMaxLength(200);

        builder.Property(u => u.Salary)
            .HasColumnName("salary")
            .HasColumnType("decimal(18,2)");

        // Endereço
        builder.Property(u => u.ZipCode)
            .HasColumnName("zip_code")
            .HasMaxLength(20);

        builder.Property(u => u.StreetAddress)
            .HasColumnName("street_address")
            .HasMaxLength(200);

        builder.Property(u => u.StreetAddressNumber)
            .HasColumnName("street_address_number")
            .HasMaxLength(20);

        builder.Property(u => u.StreetAddressComplement)
            .HasColumnName("street_address_complement")
            .HasMaxLength(200);

        builder.Property(u => u.City)
            .HasColumnName("city")
            .HasMaxLength(100);

        builder.Property(u => u.State)
            .HasColumnName("state")
            .HasMaxLength(100);

        builder.Property(u => u.Country)
            .HasColumnName("country")
            .HasMaxLength(100);

        // Passaporte
        builder.Property(u => u.PassportNumber)
            .HasColumnName("passport_number")
            .HasMaxLength(50);

        builder.Property(u => u.PassportCreated)
            .HasColumnName("passport_created")
            .HasColumnType("date");

        builder.Property(u => u.PassportExpires)
            .HasColumnName("passport_expires")
            .HasColumnType("date");

        // Visto
        builder.Property(u => u.HasVisa)
            .HasColumnName("has_visa")
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(u => u.VisaStartDate)
            .HasColumnName("visa_start_date")
            .HasColumnType("date");

        builder.Property(u => u.VisaEndDate)
            .HasColumnName("visa_end_date")
            .HasColumnType("date");

        builder.Property(u => u.AnotherInformation)
            .HasColumnName("another_information")
            .HasColumnType("text");

        // Propriedades de sistema
        builder.Property(u => u.ResetPassword)
            .HasColumnName("reset_password")
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(u => u.LastLogin)
            .HasColumnName("last_login");

        builder.Property(u => u.Status)
            .HasColumnName("status")
            .IsRequired()
            .HasConversion<int>()
            .HasDefaultValue(UserStatusEnum.ACTIVE);

        builder.Property(u => u.Created)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(u => u.Updated)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.Property(u => u.Deleted)
            .HasColumnName("deleted_at");

        // Índices
        builder.HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("ix_users_email");

        builder.HasIndex(u => u.Nif)
            .HasDatabaseName("ix_users_nif");

        builder.HasIndex(u => u.Deleted)
            .HasDatabaseName("ix_users_deleted_at");
    }
}

