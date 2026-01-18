namespace OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents an exchange rate between two currencies at a specific point in time.
/// </summary>
public class ExchangeRate : BaseEntity
{
    /// <summary>
    /// Source currency ID.
    /// </summary>
    public Guid FromCurrencyId { get; set; }

    /// <summary>
    /// Target currency ID.
    /// </summary>
    public Guid ToCurrencyId { get; set; }

    /// <summary>
    /// Date the exchange rate is effective (UTC).
    /// </summary>
    public DateTime EffectiveDate { get; set; }

    /// <summary>
    /// The exchange rate value (how many units of ToCurrency for 1 unit of FromCurrency).
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// Type of exchange rate.
    /// </summary>
    public ExchangeRateType RateType { get; set; } = ExchangeRateType.Standard;

    /// <summary>
    /// Source of the exchange rate (e.g., "Manual", "ECB", "Reuters").
    /// </summary>
    public string? Source { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Currency FromCurrency { get; set; } = null!;
    public virtual Currency ToCurrency { get; set; } = null!;
}

/// <summary>
/// Types of exchange rates.
/// </summary>
public enum ExchangeRateType
{
    Standard = 0,
    Budget = 1,
    Average = 2,
    HistoricalCost = 3
}
