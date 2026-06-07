namespace OberstoneERP.Data.MSSQL.Finance.ChartOfAccounts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for JournalEntry.
/// </summary>
public class JournalEntryConfiguration : BaseEntityConfiguration<JournalEntry>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<JournalEntry> builder)
    {
        builder.ToTable("JournalEntries", "chartofaccounts");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_JournalEntries_CompanyId");

        builder.Property(e => e.SiteId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.FiscalPeriodId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.FiscalPeriodId)
            .HasDatabaseName("IX_JournalEntries_FiscalPeriodId");

        builder.Property(e => e.EntryNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.EntryNumber })
            .IsUnique()
            .HasDatabaseName("IX_JournalEntries_CompanyId_EntryNumber");

        builder.Property(e => e.EntryDate)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(e => e.PostingDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.Reference)
            .HasMaxLength(100);

        builder.Property(e => e.EntryType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.SourceDocumentType)
            .HasConversion<int?>();

        builder.Property(e => e.SourceDocumentId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(JournalEntryStatus.Draft)
            .IsRequired();

        builder.Property(e => e.TotalDebit)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.TotalCredit)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.CurrencyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.ExchangeRate)
            .HasColumnType("decimal(19,8)")
            .HasDefaultValue(1m)
            .IsRequired();

        builder.Property(e => e.IsReversing)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.ReversedEntryId)
            .HasColumnType("uniqueidentifier");

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Site)
            .WithMany()
            .HasForeignKey(e => e.SiteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FiscalPeriod)
            .WithMany(fp => fp.JournalEntries)
            .HasForeignKey(e => e.FiscalPeriodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
