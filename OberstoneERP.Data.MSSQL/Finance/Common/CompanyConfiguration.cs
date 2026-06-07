namespace OberstoneERP.Data.MSSQL.Finance.Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Entity configuration for Company.
/// </summary>
public class CompanyConfiguration : BaseEntityConfiguration<Company>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies", "common");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.TenantId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_Companies_TenantId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.LegalName)
            .HasMaxLength(300);

        builder.Property(e => e.TaxId)
            .HasMaxLength(50);

        builder.Property(e => e.RegistrationNumber)
            .HasMaxLength(100);

        builder.Property(e => e.AddressLine1)
            .HasMaxLength(200);

        builder.Property(e => e.AddressLine2)
            .HasMaxLength(200);

        builder.Property(e => e.City)
            .HasMaxLength(100);

        builder.Property(e => e.StateProvince)
            .HasMaxLength(100);

        builder.Property(e => e.PostalCode)
            .HasMaxLength(20);

        builder.Property(e => e.CountryCode)
            .HasMaxLength(2);

        builder.Property(e => e.Email)
            .HasMaxLength(256);

        builder.Property(e => e.Phone)
            .HasMaxLength(50);

        builder.Property(e => e.Website)
            .HasMaxLength(256);

        builder.Property(e => e.DefaultCurrencyId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.FiscalYearStartMonth)
            .IsRequired();

        builder.Property(e => e.FiscalYearStartDay)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.DefaultCurrency)
            .WithMany()
            .HasForeignKey(e => e.DefaultCurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
