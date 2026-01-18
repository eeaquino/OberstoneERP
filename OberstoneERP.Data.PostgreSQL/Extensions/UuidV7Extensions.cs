namespace OberstoneERP.Data.PostgreSQL.Extensions;

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

/// <summary>
/// EF Core value generator for UUID v7.
/// Uses the built-in .NET 9+ Guid.CreateVersion7() method to generate time-ordered UUIDs.
/// PostgreSQL natively supports UUID types and Npgsql handles conversion automatically.
/// </summary>
public class UuidV7ValueGenerator : ValueGenerator<Guid>
{
    /// <summary>
    /// Gets a value indicating whether the values generated are temporary.
    /// </summary>
    public override bool GeneratesTemporaryValues => false;

    /// <summary>
    /// Generates a new UUID v7 value using the built-in .NET method.
    /// </summary>
    /// <param name="entry">The entity entry for which the value is being generated.</param>
    /// <returns>A new UUID v7.</returns>
    public override Guid Next(EntityEntry entry)
    {
        return Guid.CreateVersion7();
    }
}
