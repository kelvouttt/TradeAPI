namespace InstrumentApi.Models;

public enum AssetClass
{
    Equity,
    Bond,
    Futures,
    Options,
    Forex,
    Crypto,
    ETF
}

public enum Exchange
{
    NYSE,
    TSE,
    LSE,
    NSE,
    ASX,
    NASDAQ,
    SSE,
    HKEX,
    Euronext
}

public enum Currency
{
    USD,
    JPY,
    AUD,
    GBP,
    CNY,
    HKD,
    EUR
}

public class Instrument
{
    public string Symbol { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public AssetClass AssetClass { get; set; }
    public Exchange Exchange { get; set; }
    public Currency Currency { get; set; }

    // Market data
    public decimal LastPrice { get; set; }
    public decimal Bid { get; set; }
    public decimal Ask { get; set; }

    public override string ToString()
    {
        return $"{Symbol} ({Exchange}) - {AssetClass}";
    }
}