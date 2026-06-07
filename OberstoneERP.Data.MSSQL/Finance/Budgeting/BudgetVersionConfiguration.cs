namespace OberstoneERP.Data.MSSQL.Finance.Budgeting;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Budgeting;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for BudgetVersion.
/// </summary>
public class BudgetVersionConfiguration : BaseEntityConfiguration<BudgetVersion>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<BudgetVersion> builder)
    {
        builder.ToTable("BudgetVersions", "budgeting");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_BudgetVersions_CompanyId");

        builder.Property(e => e.FiscalYearId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.FiscalYearId)
            .HasDatabaseName("IX_BudgetVersions_FiscalYearId");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.FiscalYearId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_BudgetVersions_CompanyId_FiscalYearId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.VersionType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(BudgetVersionStatus.Draft)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.CurrencyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.ApprovedDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.ApprovedBy)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.Notes)
            .HasMaxLength(1000);

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FiscalYear)
            .WithMany()
            .HasForeignKey(e => e.FiscalYearId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
