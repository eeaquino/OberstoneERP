namespace OberstoneERP.Data.PostgreSQL.Finance.Taxes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Taxes;
using OberstoneERP.Data.PostgreSQL.Finance.Common;

/// <summary>
/// Entity configuration for TaxCode.
/// </summary>
public class TaxCodeConfiguration : BaseEntityConfiguration<TaxCode>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<TaxCode> builder)
    {
        builder.ToTable("TaxCodes", "taxes");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_TaxCodes_CompanyId");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_TaxCodes_CompanyId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.TaxType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Category)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.CountryCode)
            .HasMaxLength(2);

        builder.Property(e => e.StateProvinceCode)
            .HasMaxLength(10);

        builder.Property(e => e.TaxAuthority)
            .HasMaxLength(200);

        builder.Property(e => e.TaxPayableAccountId)
            .HasColumnType("uuid");

        builder.Property(e => e.TaxReceivableAccountId)
            .HasColumnType("uuid");

        builder.Property(e => e.TaxExpenseAccountId)
            .HasColumnType("uuid");

        builder.Property(e => e.IsRecoverable)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.RecoveryPercent)
            .HasColumnType("decimal(5,2)")
            .HasDefaultValue(100m)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TaxPayableAccount)
            .WithMany()
            .HasForeignKey(e => e.TaxPayableAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TaxReceivableAccount)
            .WithMany()
            .HasForeignKey(e => e.TaxReceivableAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TaxExpenseAccount)
            .WithMany()
            .HasForeignKey(e => e.TaxExpenseAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
