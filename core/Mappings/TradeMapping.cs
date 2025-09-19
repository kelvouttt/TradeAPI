using TradeApi.Models;
using TradeApi.Dtos;

namespace TradeApi.Mappings;

public static class TradeApiMapping
{
    public static TradeDto ToDto(this Trade trade)
    {
        return new TradeDto
        {
            TradeId = trade.TradeId,
            Instrument = trade.Instrument,
            Quantity = trade.Quantity,
            Price = trade.Price,
            Counterparty = trade.Counterparty,
            PortfolioName = trade.Portfolio?.PortfolioName ?? ""
        };
    }
}