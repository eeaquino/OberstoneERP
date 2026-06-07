namespace OberstoneERP.Data.MariaDB.Finance.Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Entity configuration for Site.
/// </summary>
public class SiteConfiguration : BaseEntityConfiguration<Site>
{
    /// <inheritdoc/>
    protected override void ConfigureEntity(EntityTypeBuilder<Site> builder)
    {
        builder.ToTable("Sites");

        builder.Property(e => e.CompanyId)
            .HasColumnType("char(36)")
            .IsRequired();

        builder.HasIndex(e => e.CompanyId)
            .HasDatabaseName("IX_Sites_CompanyId");

        builder.Property(e => e.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(e => new { e.CompanyId, e.Code })
            .IsUnique()
            .HasDatabaseName("IX_Sites_CompanyId_Code");

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.SiteType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.AddressLine1)
            .HasMaxLength(200);

        builder.Property(e => e.AddressLine2)
            .HasMaxLength(200);

        builder.Property(e => e.City)
            .HasMaxLength(100);

        builder.Property(e => e.StateProvince)
            .HasMaxLength(100);

        builder.Property(e => e.PostalCode)
            .HasMaxLength(20);

        builder.Property(e => e.CountryCode)
            .HasMaxLength(2);

        builder.Property(e => e.Phone)
            .HasMaxLength(50);

        builder.Property(e => e.Email)
            .HasMaxLength(256);

        builder.Property(e => e.TimeZoneId)
            .HasMaxLength(100);

        builder.Property(e => e.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        // Navigation properties
        builder.HasOne(e => e.Company)
            .WithMany(c => c.Sites)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
