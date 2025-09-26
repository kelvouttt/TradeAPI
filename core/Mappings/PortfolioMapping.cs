using Models.Domain.PortfolioAPI;
using Models.Dtos.PortfolioApi;
using Mappings.TradeAPI;

namespace Mappings.PortfolioAPI;

public static class PortfolioApiMapping
{
    public static PortfolioDto ToDto(this Portfolio portfolio)
    {
        return new PortfolioDto
        {
            PortfolioName = portfolio.PortfolioName,
            Trades = portfolio.Trades.Select(t => t.ToDto()).ToList()
        };
    }
}