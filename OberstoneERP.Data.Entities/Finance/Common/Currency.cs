namespace OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a currency used in financial transactions.
/// </summary>
public class Currency : BaseEntity
{
    /// <summary>
    /// ISO 4217 currency code (e.g., USD, EUR, GBP).
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Name of the currency (e.g., "US Dollar").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Currency symbol (e.g., $, €, £).
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Number of decimal places for the currency (typically 2).
    /// </summary>
    public int DecimalPlaces { get; set; } = 2;

    /// <summary>
    /// Indicates whether the symbol appears before the amount.
    /// </summary>
    public bool SymbolBefore { get; set; } = true;

    /// <summary>
    /// Decimal separator character.
    /// </summary>
    public string DecimalSeparator { get; set; } = ".";

    /// <summary>
    /// Thousands separator character.
    /// </summary>
    public string ThousandsSeparator { get; set; } = ",";

    /// <summary>
    /// Indicates whether the currency is active and available for use.
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual ICollection<ExchangeRate> ExchangeRatesFrom { get; set; } = [];
    public virtual ICollection<ExchangeRate> ExchangeRatesTo { get; set; } = [];
}
