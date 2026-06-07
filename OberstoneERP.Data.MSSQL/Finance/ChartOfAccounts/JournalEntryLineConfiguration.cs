namespace OberstoneERP.Data.MSSQL.Finance.ChartOfAccounts;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for JournalEntryLine.
/// </summary>
public class JournalEntryLineConfiguration : BaseEntityConfiguration<JournalEntryLine>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<JournalEntryLine> builder)
    {
        builder.ToTable("JournalEntryLines", "chartofaccounts");

        builder.Property(e => e.JournalEntryId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.JournalEntryId)
            .HasDatabaseName("IX_JournalEntryLines_JournalEntryId");

        builder.Property(e => e.AccountId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.AccountId)
            .HasDatabaseName("IX_JournalEntryLines_AccountId");

        builder.Property(e => e.LineNumber)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.DebitAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.CreditAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.FunctionalAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.CostCenterId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.ProfitCenterId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.InternalOrderId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.TaxCodeId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.TaxAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.CustomerId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.VendorId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.AssetId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.IsReconciled)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.ReconciledDate)
            .HasColumnType("datetime2");

        // Navigation properties
        builder.HasOne(e => e.JournalEntry)
            .WithMany(je => je.Lines)
            .HasForeignKey(e => e.JournalEntryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Account)
            .WithMany(a => a.JournalEntryLines)
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.CostCenter)
            .WithMany()
            .HasForeignKey(e => e.CostCenterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ProfitCenter)
            .WithMany()
            .HasForeignKey(e => e.ProfitCenterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.InternalOrder)
            .WithMany()
            .HasForeignKey(e => e.InternalOrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
