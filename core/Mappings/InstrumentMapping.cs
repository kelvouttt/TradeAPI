using Models.Dtos.InstrumentAPI;
using Models.Domain.InstrumentAPI;
using Mappings.TradeAPI;

namespace Mappings.InstrumentAPI;


public static class InstrumentAPIMapping
{
    public static InstrumentDto ToDto(this Instrument instrument)
    {
        return new InstrumentDto
        {
            Symbol = instrument.Symbol,
            Name = instrument.Name,
            AssetClass = instrument.AssetClass,
            Exchange = instrument.Exchange,
            Currency = instrument.Currency,
            Trades = instrument.Trades.Select(t => t.ToDto()).ToList(),
            LastPrice = instrument.LastPrice,
            Bid = instrument.Bid,
            Ask = instrument.Ask
        };
    }
}