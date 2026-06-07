namespace OberstoneERP.Data.MariaDB.Finance.Controlling;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Controlling;
using OberstoneERP.Data.MariaDB.Finance.Common;

/// <summary>
/// Entity configuration for ProfitCenter.
/// </summary>
public class ProfitCenterConfiguration : BaseEntityConfiguration<ProfitCenter>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<ProfitCenter> builder)
    {
        builder.ToTable("ProfitCenters");

        builder.Property(e => e.CompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_ProfitCenters_CompanyId");

        builder.Property(e => e.SiteId)
            .HasColumnType("char(36)");

        builder.Property(e => e.ParentProfitCenterId)
            .HasColumnType("char(36)");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_ProfitCenters_CompanyId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.Level)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.HierarchyPath)
            .HasMaxLength(500);

        builder.Property(e => e.ManagerId)
            .HasColumnType("char(36)");

        builder.Property(e => e.ValidFrom)
            .HasColumnType("datetime(6)");

        builder.Property(e => e.ValidTo)
            .HasColumnType("datetime(6)");

        builder.Property(e => e.RevenueTarget)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.ActualRevenue)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.CostTarget)
            .HasColumnType("decimal(19,4)")
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(e => e.ActualCost)
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

        builder.HasOne(e => e.ParentProfitCenter)
            .WithMany(pc => pc.ChildProfitCenters)
            .HasForeignKey(e => e.ParentProfitCenterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
