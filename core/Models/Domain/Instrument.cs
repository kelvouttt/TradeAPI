using Models.Enums.AssetClass;
using Models.Enums.Exchange;
using Models.Enums.Currency;
using Models.Domain.TradeAPI;

namespace Models.Domain.InstrumentAPI;

public class Instrument
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Symbol { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public AssetClass AssetClass { get; set; }
    public Exchange Exchange { get; set; }
    public Currency Currency { get; set; }

    public ICollection<Trade> Trades { get; set; } = new List<Trade>();

    // Market data
    public decimal LastPrice { get; set; }
    public decimal Bid { get; set; }
    public decimal Ask { get; set; }

    public override string ToString()
    {
        return $"{Symbol} ({Exchange}) - {AssetClass}";
    }
}