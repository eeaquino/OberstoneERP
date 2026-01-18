namespace OberstoneERP.Data.Entities.Finance.Treasury;

using OberstoneERP.Data.Entities.Finance.Common;

/// <summary>
/// Represents a cash flow forecast entry.
/// </summary>
public class CashFlowForecast : BaseEntity
{
    /// <summary>
    /// Company this forecast belongs to.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Bank account this forecast relates to.
    /// </summary>
    public Guid? BankAccountId { get; set; }

    /// <summary>
    /// Cash flow category ID.
    /// </summary>
    public Guid CashFlowCategoryId { get; set; }

    /// <summary>
    /// Currency ID.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// Forecast date or period start date.
    /// </summary>
    public DateTime ForecastDate { get; set; }

    /// <summary>
    /// Period end date (for period-based forecasts).
    /// </summary>
    public DateTime? PeriodEndDate { get; set; }

    /// <summary>
    /// Type of forecast entry.
    /// </summary>
    public CashFlowForecastType ForecastType { get; set; }

    /// <summary>
    /// Description of the forecast entry.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Reference to source document or entity.
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// Forecasted inflow amount.
    /// </summary>
    public decimal InflowAmount { get; set; }

    /// <summary>
    /// Forecasted outflow amount.
    /// </summary>
    public decimal OutflowAmount { get; set; }

    /// <summary>
    /// Net amount (inflow - outflow).
    /// </summary>
    public decimal NetAmount => InflowAmount - OutflowAmount;

    /// <summary>
    /// Probability of occurrence (0-100%).
    /// </summary>
    public decimal Probability { get; set; } = 100;

    /// <summary>
    /// Weighted amount (NetAmount * Probability / 100).
    /// </summary>
    public decimal WeightedAmount => NetAmount * Probability / 100;

    /// <summary>
    /// Source of the forecast data.
    /// </summary>
    public CashFlowForecastSource Source { get; set; }

    /// <summary>
    /// Source document ID if system-generated.
    /// </summary>
    public Guid? SourceDocumentId { get; set; }

    /// <summary>
    /// Status of the forecast entry.
    /// </summary>
    public CashFlowForecastStatus Status { get; set; } = CashFlowForecastStatus.Active;

    /// <summary>
    /// Actual amount when realized.
    /// </summary>
    public decimal? ActualAmount { get; set; }

    /// <summary>
    /// Date the forecast was realized.
    /// </summary>
    public DateTime? RealizedDate { get; set; }

    /// <summary>
    /// Notes about the forecast entry.
    /// </summary>
    public string? Notes { get; set; }

    // Navigation properties
    public virtual Tenant Tenant { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual BankAccount? BankAccount { get; set; }
    public virtual CashFlowCategory CashFlowCategory { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;
}

/// <summary>
/// Types of cash flow forecast entries.
/// </summary>
public enum CashFlowForecastType
{
    /// <summary>
    /// Based on actual receivables.
    /// </summary>
    Receivable = 0,

    /// <summary>
    /// Based on actual payables.
    /// </summary>
    Payable = 1,

    /// <summary>
    /// Recurring/scheduled item.
    /// </summary>
    Recurring = 2,

    /// <summary>
    /// Manual forecast entry.
    /// </summary>
    Manual = 3,

    /// <summary>
    /// Budget-based forecast.
    /// </summary>
    Budget = 4,

    /// <summary>
    /// Loan payment.
    /// </summary>
    LoanPayment = 5,

    /// <summary>
    /// Payroll.
    /// </summary>
    Payroll = 6,

    /// <summary>
    /// Tax payment.
    /// </summary>
    TaxPayment = 7
}

/// <summary>
/// Sources of cash flow forecast data.
/// </summary>
public enum CashFlowForecastSource
{
    /// <summary>
    /// Manually entered.
    /// </summary>
    Manual = 0,

    /// <summary>
    /// System-generated from AR.
    /// </summary>
    AccountsReceivable = 1,

    /// <summary>
    /// System-generated from AP.
    /// </summary>
    AccountsPayable = 2,

    /// <summary>
    /// From budget system.
    /// </summary>
    Budget = 3,

    /// <summary>
    /// External import.
    /// </summary>
    Import = 4
}

/// <summary>
/// Status of a cash flow forecast entry.
/// </summary>
public enum CashFlowForecastStatus
{
    Active = 0,
    Realized = 1,
    Cancelled = 2,
    Expired = 3
}
