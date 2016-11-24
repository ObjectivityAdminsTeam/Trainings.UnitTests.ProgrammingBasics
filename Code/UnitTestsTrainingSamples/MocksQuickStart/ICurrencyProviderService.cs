namespace MocksQuickStart
{
    public interface ICurrencyProviderService
    {
        ServiceStatus Status { get; set; }

        decimal GetExchangeRate(string currencyCode);

        bool IsCurrencyAvailable(string currencyCode);
    }
}
