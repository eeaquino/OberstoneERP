namespace OberstoneERP.Data.MSSQL.Finance.Controlling;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Controlling;
using OberstoneERP.Data.MSSQL.Finance.Common;

/// <summary>
/// Entity configuration for CostCenter.
/// </summary>
public class CostCenterConfiguration : BaseEntityConfiguration<CostCenter>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<CostCenter> builder)
    {
        builder.ToTable("CostCenters", "controlling");

        builder.Property(e => e.CompanyId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_CostCenters_CompanyId");

        builder.Property(e => e.SiteId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.ParentCostCenterId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_CostCenters_CompanyId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.CostCenterType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.Level)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.HierarchyPath)
            .HasMaxLength(500);

        builder.Property(e => e.ManagerId)
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.ValidFrom)
            .HasColumnType("datetime2");

        builder.Property(e => e.ValidTo)
            .HasColumnType("datetime2");

        builder.Property(e => e.BudgetAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.ActualAmount)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Site)
            .WithMany()
            .HasForeignKey(e => e.SiteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ParentCostCenter)
            .WithMany(cc => cc.ChildCostCenters)
            .HasForeignKey(e => e.ParentCostCenterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
