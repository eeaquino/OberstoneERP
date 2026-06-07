namespace OberstoneERP.Data.MSSQL.Finance.ChartOfAccounts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for FiscalYear.
/// </summary>
public class FiscalYearConfiguration : BaseEntityConfiguration<FiscalYear>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<FiscalYear> builder)
    {
        builder.ToTable("FiscalYears", "chartofaccounts");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_FiscalYears_CompanyId");

        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Name })
            .IsUnique()
            .HasDatabaseName("IX_FiscalYears_CompanyId_Name");

        builder.Property(e => e.StartDate)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(e => e.EndDate)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(FiscalYearStatus.Open)
            .IsRequired();

        builder.Property(e => e.IsCurrent)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.ClosingDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.ClosedBy)
            .HasColumnType("uniqueidentifier");

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
