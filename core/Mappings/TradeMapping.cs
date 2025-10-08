using Models.Domain.TradeAPI;
using Models.Dtos.TradeAPI;


namespace Mappings.TradeAPI;

public static class TradeApiMapping
{
    public static TradeDto ToDto(this Trade trade)
    {
        return new TradeDto
        {
            TradeId = trade.TradeId,
            Instrument = trade.Instrument?.Symbol,
            Quantity = trade.Quantity,
            Price = trade.Price,
            Counterparty = trade.Counterparty,
            PortfolioName = trade.Portfolio?.PortfolioName ?? ""
        };
    }
}