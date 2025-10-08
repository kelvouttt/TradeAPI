using Models.Dtos.TradeAPI;
using Models.Enums.AssetClass;
using Models.Enums.Currency;
using Models.Enums.Exchange;

namespace Models.Dtos.InstrumentAPI;


public class InstrumentDto
{
    public string? Symbol { get; set; }
    public string? Name { get; set; }
    public AssetClass AssetClass { get; set; }
    public Exchange Exchange { get; set; }
    public Currency Currency { get; set; }
    public ICollection<TradeDto> Trades { get; set; } = new List<TradeDto>();
    public decimal LastPrice { get; set; }
    public decimal Bid { get; set; }
    public decimal Ask { get; set; }
}