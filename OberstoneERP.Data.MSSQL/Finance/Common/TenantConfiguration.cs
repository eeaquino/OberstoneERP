namespace OberstoneERP.Data.MSSQL.Finance.Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.MSSQL.Extensions;

/// <summary>
/// Entity configuration for Tenant.
/// Tenant is the root entity and does not inherit from BaseEntity.
/// </summary>
public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenants", "common");

        // Primary key with UUID v7 generation
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnType("uniqueidentifier")
            .HasValueGenerator<UuidV7ValueGenerator>()
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => e.Code)
            .IsUnique()
            .HasDatabaseName("IX_Tenants_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.LegalName)
            .HasMaxLength(300);

        builder.Property(e => e.Email)
            .HasMaxLength(256);

        builder.Property(e => e.Phone)
            .HasMaxLength(50);

        builder.Property(e => e.TimeZoneId)
            .HasMaxLength(100)
            .HasDefaultValue("UTC")
            .IsRequired();

        builder.Property(e => e.Locale)
            .HasMaxLength(20)
            .HasDefaultValue("en-US")
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(e => e.ModifiedAt)
            .HasColumnType("datetime2");
    }
}
