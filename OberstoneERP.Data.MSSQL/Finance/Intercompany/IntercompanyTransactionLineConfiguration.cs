namespace OberstoneERP.Data.MSSQL.Finance.Intercompany;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Intercompany;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for IntercompanyTransactionLine.
/// </summary>
public class IntercompanyTransactionLineConfiguration : BaseEntityConfiguration<IntercompanyTransactionLine>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<IntercompanyTransactionLine> builder)
    {
        builder.ToTable("IntercompanyTransactionLines", "intercompany");

        builder.Property(e => e.IntercompanyTransactionId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.IntercompanyTransactionId)
            .HasDatabaseName("IX_IntercompanyTransactionLines_IntercompanyTransactionId");

        builder.Property(e => e.LineNumber)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(e => e.ItemCode)
            .HasMaxLength(50);

        builder.Property(e => e.SourceAccountId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.TargetAccountId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.Quantity)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(1m)
            .IsRequired();

        builder.Property(e => e.UnitOfMeasure)
            .HasMaxLength(50);

        builder.Property(e => e.UnitPrice)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Amount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.SourceCostCenterId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.SourceProfitCenterId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.TargetCostCenterId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.TargetProfitCenterId)
            .HasColumnType("uniqueidentifier");

        // Navigation properties
        builder.HasOne(e => e.IntercompanyTransaction)
            .WithMany(it => it.Lines)
            .HasForeignKey(e => e.IntercompanyTransactionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.SourceAccount)
            .WithMany()
            .HasForeignKey(e => e.SourceAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TargetAccount)
            .WithMany()
            .HasForeignKey(e => e.TargetAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.SourceCostCenter)
            .WithMany()
            .HasForeignKey(e => e.SourceCostCenterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.SourceProfitCenter)
            .WithMany()
            .HasForeignKey(e => e.SourceProfitCenterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TargetCostCenter)
            .WithMany()
            .HasForeignKey(e => e.TargetCostCenterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TargetProfitCenter)
            .WithMany()
            .HasForeignKey(e => e.TargetProfitCenterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
