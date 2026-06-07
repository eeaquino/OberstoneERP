namespace OberstoneERP.Data.MSSQL.Finance.Controlling;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Controlling;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for InternalOrder.
/// </summary>
public class InternalOrderConfiguration : BaseEntityConfiguration<InternalOrder>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<InternalOrder> builder)
    {
        builder.ToTable("InternalOrders", "controlling");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_InternalOrders_CompanyId");

        builder.Property(e => e.SiteId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.OrderNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.OrderNumber })
            .IsUnique()
            .HasDatabaseName("IX_InternalOrders_CompanyId_OrderNumber");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.OrderType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Category)
            .HasMaxLength(100);

        builder.Property(e => e.ResponsibleCostCenterId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.ManagerId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.PlannedStartDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.PlannedEndDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.ActualStartDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.ActualEndDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.CurrencyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(e => e.PlannedCost)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.ActualCost)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.CommittedCost)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.PlannedRevenue)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.ActualRevenue)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .HasDefaultValue(InternalOrderStatus.Created)
            .IsRequired();

        builder.Property(e => e.AllowPosting)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.BudgetControlEnabled)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(e => e.SettlementCostCenterId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.SettlementPercent)
            .HasColumnType("decimal(5,2)")
            .HasDefaultValue(100m)
            .IsRequired();

        builder.Property(e => e.ClosedDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.Notes)
            .HasMaxLength(1000);

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Site)
            .WithMany()
            .HasForeignKey(e => e.SiteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ResponsibleCostCenter)
            .WithMany()
            .HasForeignKey(e => e.ResponsibleCostCenterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
