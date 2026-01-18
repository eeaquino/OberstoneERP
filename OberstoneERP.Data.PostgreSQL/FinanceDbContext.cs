namespace OberstoneERP.Data.PostgreSQL;

using Microsoft.EntityFrameworkCore;
using OberstoneERP.Data.Entities.Finance.AccountsPayable;
using OberstoneERP.Data.Entities.Finance.AccountsReceivable;
using OberstoneERP.Data.Entities.Finance.Budgeting;
using OberstoneERP.Data.Entities.Finance.ChartOfAccounts;
using OberstoneERP.Data.Entities.Finance.Common;
using OberstoneERP.Data.Entities.Finance.Controlling;
using OberstoneERP.Data.Entities.Finance.FixedAssets;
using OberstoneERP.Data.Entities.Finance.Intercompany;
using OberstoneERP.Data.Entities.Finance.Taxes;
using OberstoneERP.Data.Entities.Finance.Treasury;

/// <summary>
/// Entity Framework Core DbContext for the Finance module using PostgreSQL.
/// This context manages all Finance-related entities and their configurations.
/// </summary>
public class FinanceDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FinanceDbContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext.</param>
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
        : base(options)
    {
    }

    #region Common Entities

    /// <summary>
    /// Gets or sets the Tenants DbSet.
    /// </summary>
    public DbSet<Tenant> Tenants => Set<Tenant>();

    /// <summary>
    /// Gets or sets the Companies DbSet.
    /// </summary>
    public DbSet<Company> Companies => Set<Company>();

    /// <summary>
    /// Gets or sets the Sites DbSet.
    /// </summary>
    public DbSet<Site> Sites => Set<Site>();

    /// <summary>
    /// Gets or sets the Currencies DbSet.
    /// </summary>
    public DbSet<Currency> Currencies => Set<Currency>();

    /// <summary>
    /// Gets or sets the Exchange Rates DbSet.
    /// </summary>
    public DbSet<ExchangeRate> ExchangeRates => Set<ExchangeRate>();

    #endregion

    #region Chart of Accounts Entities

    /// <summary>
    /// Gets or sets the Account Types DbSet.
    /// </summary>
    public DbSet<AccountType> AccountTypes => Set<AccountType>();

    /// <summary>
    /// Gets or sets the Account Groups DbSet.
    /// </summary>
    public DbSet<AccountGroup> AccountGroups => Set<AccountGroup>();

    /// <summary>
    /// Gets or sets the Accounts DbSet.
    /// </summary>
    public DbSet<Account> Accounts => Set<Account>();

    /// <summary>
    /// Gets or sets the Fiscal Years DbSet.
    /// </summary>
    public DbSet<FiscalYear> FiscalYears => Set<FiscalYear>();

    /// <summary>
    /// Gets or sets the Fiscal Periods DbSet.
    /// </summary>
    public DbSet<FiscalPeriod> FiscalPeriods => Set<FiscalPeriod>();

    /// <summary>
    /// Gets or sets the Journal Entries DbSet.
    /// </summary>
    public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();

    /// <summary>
    /// Gets or sets the Journal Entry Lines DbSet.
    /// </summary>
    public DbSet<JournalEntryLine> JournalEntryLines => Set<JournalEntryLine>();

    #endregion

    #region Accounts Receivable Entities

    /// <summary>
    /// Gets or sets the Customer Groups DbSet.
    /// </summary>
    public DbSet<CustomerGroup> CustomerGroups => Set<CustomerGroup>();

    /// <summary>
    /// Gets or sets the Payment Terms DbSet.
    /// </summary>
    public DbSet<PaymentTerms> PaymentTerms => Set<PaymentTerms>();

    /// <summary>
    /// Gets or sets the Customers DbSet.
    /// </summary>
    public DbSet<Customer> Customers => Set<Customer>();

    /// <summary>
    /// Gets or sets the Customer Invoices DbSet.
    /// </summary>
    public DbSet<CustomerInvoice> CustomerInvoices => Set<CustomerInvoice>();

    /// <summary>
    /// Gets or sets the Customer Invoice Lines DbSet.
    /// </summary>
    public DbSet<CustomerInvoiceLine> CustomerInvoiceLines => Set<CustomerInvoiceLine>();

    /// <summary>
    /// Gets or sets the Customer Payments DbSet.
    /// </summary>
    public DbSet<CustomerPayment> CustomerPayments => Set<CustomerPayment>();

    /// <summary>
    /// Gets or sets the Customer Payment Allocations DbSet.
    /// </summary>
    public DbSet<CustomerPaymentAllocation> CustomerPaymentAllocations => Set<CustomerPaymentAllocation>();

    /// <summary>
    /// Gets or sets the Customer Credit Notes DbSet.
    /// </summary>
    public DbSet<CustomerCreditNote> CustomerCreditNotes => Set<CustomerCreditNote>();

    /// <summary>
    /// Gets or sets the Customer Credit Note Lines DbSet.
    /// </summary>
    public DbSet<CustomerCreditNoteLine> CustomerCreditNoteLines => Set<CustomerCreditNoteLine>();

    #endregion

    #region Accounts Payable Entities

    /// <summary>
    /// Gets or sets the Vendor Groups DbSet.
    /// </summary>
    public DbSet<VendorGroup> VendorGroups => Set<VendorGroup>();

    /// <summary>
    /// Gets or sets the Vendors DbSet.
    /// </summary>
    public DbSet<Vendor> Vendors => Set<Vendor>();

    /// <summary>
    /// Gets or sets the Vendor Invoices DbSet.
    /// </summary>
    public DbSet<VendorInvoice> VendorInvoices => Set<VendorInvoice>();

    /// <summary>
    /// Gets or sets the Vendor Invoice Lines DbSet.
    /// </summary>
    public DbSet<VendorInvoiceLine> VendorInvoiceLines => Set<VendorInvoiceLine>();

    /// <summary>
    /// Gets or sets the Vendor Payments DbSet.
    /// </summary>
    public DbSet<VendorPayment> VendorPayments => Set<VendorPayment>();

    /// <summary>
    /// Gets or sets the Vendor Payment Allocations DbSet.
    /// </summary>
    public DbSet<VendorPaymentAllocation> VendorPaymentAllocations => Set<VendorPaymentAllocation>();

    /// <summary>
    /// Gets or sets the Vendor Debit Notes DbSet.
    /// </summary>
    public DbSet<VendorDebitNote> VendorDebitNotes => Set<VendorDebitNote>();

    /// <summary>
    /// Gets or sets the Vendor Debit Note Lines DbSet.
    /// </summary>
    public DbSet<VendorDebitNoteLine> VendorDebitNoteLines => Set<VendorDebitNoteLine>();

    #endregion

    #region Fixed Assets Entities

    /// <summary>
    /// Gets or sets the Depreciation Methods DbSet.
    /// </summary>
    public DbSet<DepreciationMethod> DepreciationMethods => Set<DepreciationMethod>();

    /// <summary>
    /// Gets or sets the Asset Categories DbSet.
    /// </summary>
    public DbSet<AssetCategory> AssetCategories => Set<AssetCategory>();

    /// <summary>
    /// Gets or sets the Assets DbSet.
    /// </summary>
    public DbSet<Asset> Assets => Set<Asset>();

    /// <summary>
    /// Gets or sets the Asset Depreciations DbSet.
    /// </summary>
    public DbSet<AssetDepreciation> AssetDepreciations => Set<AssetDepreciation>();

    /// <summary>
    /// Gets or sets the Asset Disposals DbSet.
    /// </summary>
    public DbSet<AssetDisposal> AssetDisposals => Set<AssetDisposal>();

    #endregion

    #region Controlling Entities

    /// <summary>
    /// Gets or sets the Cost Centers DbSet.
    /// </summary>
    public DbSet<CostCenter> CostCenters => Set<CostCenter>();

    /// <summary>
    /// Gets or sets the Cost Elements DbSet.
    /// </summary>
    public DbSet<CostElement> CostElements => Set<CostElement>();

    /// <summary>
    /// Gets or sets the Profit Centers DbSet.
    /// </summary>
    public DbSet<ProfitCenter> ProfitCenters => Set<ProfitCenter>();

    /// <summary>
    /// Gets or sets the Internal Orders DbSet.
    /// </summary>
    public DbSet<InternalOrder> InternalOrders => Set<InternalOrder>();

    /// <summary>
    /// Gets or sets the Item Costs DbSet.
    /// </summary>
    public DbSet<ItemCost> ItemCosts => Set<ItemCost>();

    /// <summary>
    /// Gets or sets the Item Cost Histories DbSet.
    /// </summary>
    public DbSet<ItemCostHistory> ItemCostHistories => Set<ItemCostHistory>();

    #endregion

    #region Budgeting Entities

    /// <summary>
    /// Gets or sets the Budget Versions DbSet.
    /// </summary>
    public DbSet<BudgetVersion> BudgetVersions => Set<BudgetVersion>();

    /// <summary>
    /// Gets or sets the Budgets DbSet.
    /// </summary>
    public DbSet<Budget> Budgets => Set<Budget>();

    /// <summary>
    /// Gets or sets the Budget Lines DbSet.
    /// </summary>
    public DbSet<BudgetLine> BudgetLines => Set<BudgetLine>();

    /// <summary>
    /// Gets or sets the Budget Transfers DbSet.
    /// </summary>
    public DbSet<BudgetTransfer> BudgetTransfers => Set<BudgetTransfer>();

    #endregion

    #region Taxes Entities

    /// <summary>
    /// Gets or sets the Tax Codes DbSet.
    /// </summary>
    public DbSet<TaxCode> TaxCodes => Set<TaxCode>();

    /// <summary>
    /// Gets or sets the Tax Rates DbSet.
    /// </summary>
    public DbSet<TaxRate> TaxRates => Set<TaxRate>();

    /// <summary>
    /// Gets or sets the Tax Transactions DbSet.
    /// </summary>
    public DbSet<TaxTransaction> TaxTransactions => Set<TaxTransaction>();

    /// <summary>
    /// Gets or sets the Tax Return Periods DbSet.
    /// </summary>
    public DbSet<TaxReturnPeriod> TaxReturnPeriods => Set<TaxReturnPeriod>();

    #endregion

    #region Treasury Entities

    /// <summary>
    /// Gets or sets the Bank Accounts DbSet.
    /// </summary>
    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();

    /// <summary>
    /// Gets or sets the Bank Transactions DbSet.
    /// </summary>
    public DbSet<BankTransaction> BankTransactions => Set<BankTransaction>();

    /// <summary>
    /// Gets or sets the Bank Reconciliations DbSet.
    /// </summary>
    public DbSet<BankReconciliation> BankReconciliations => Set<BankReconciliation>();

    /// <summary>
    /// Gets or sets the Cash Flow Categories DbSet.
    /// </summary>
    public DbSet<CashFlowCategory> CashFlowCategories => Set<CashFlowCategory>();

    /// <summary>
    /// Gets or sets the Cash Flow Forecasts DbSet.
    /// </summary>
    public DbSet<CashFlowForecast> CashFlowForecasts => Set<CashFlowForecast>();

    #endregion

    #region Intercompany Entities

    /// <summary>
    /// Gets or sets the Intercompany Agreements DbSet.
    /// </summary>
    public DbSet<IntercompanyAgreement> IntercompanyAgreements => Set<IntercompanyAgreement>();

    /// <summary>
    /// Gets or sets the Intercompany Transactions DbSet.
    /// </summary>
    public DbSet<IntercompanyTransaction> IntercompanyTransactions => Set<IntercompanyTransaction>();

    /// <summary>
    /// Gets or sets the Intercompany Transaction Lines DbSet.
    /// </summary>
    public DbSet<IntercompanyTransactionLine> IntercompanyTransactionLines => Set<IntercompanyTransactionLine>();

    #endregion

    /// <summary>
    /// Configures the model for the Finance module.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to construct the model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all configurations from this assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinanceDbContext).Assembly);
    }
}
