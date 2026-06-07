namespace OberstoneERP.Data.MSSQL.Finance.AccountsReceivable;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for CustomerCreditNoteLine.
/// </summary>
public class CustomerCreditNoteLineConfiguration : BaseEntityConfiguration<CustomerCreditNoteLine>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<CustomerCreditNoteLine> builder)
    {
        builder.ToTable("CustomerCreditNoteLines", "accountsreceivable");

        builder.Property(e => e.CustomerCreditNoteId).HasColumnType("uniqueidentifier").IsRequired();
        builder.HasIndex(e => e.CustomerCreditNoteId).HasDatabaseName("IX_CustomerCreditNoteLines_CustomerCreditNoteId");
        builder.Property(e => e.LineNumber).IsRequired();
        builder.Property(e => e.ItemCode).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(500).IsRequired();
        builder.Property(e => e.AccountId).HasColumnType("uniqueidentifier").IsRequired();
        builder.Property(e => e.Quantity).HasColumnType("decimal(19,4)").HasDefaultValue(1m).IsRequired();
        builder.Property(e => e.UnitOfMeasure).HasMaxLength(50);
        builder.Property(e => e.UnitPrice).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.NetAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.TaxCodeId).HasColumnType("uniqueidentifier");
        builder.Property(e => e.TaxAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();
        builder.Property(e => e.TotalAmount).HasColumnType("decimal(19,4)").HasDefaultValue(0m).IsRequired();

        // Navigation properties
        builder.HasOne(e => e.CustomerCreditNote).WithMany(ccn => ccn.Lines).HasForeignKey(e => e.CustomerCreditNoteId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Account).WithMany().HasForeignKey(e => e.AccountId).OnDelete(DeleteBehavior.Restrict);
    }
}
