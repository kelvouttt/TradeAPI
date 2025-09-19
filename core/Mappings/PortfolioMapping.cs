using PortfolioApi.Models;
using PortfolioApi.Dtos;
using TradeApi.Mappings;

namespace PortfolioApi.Mappings;

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