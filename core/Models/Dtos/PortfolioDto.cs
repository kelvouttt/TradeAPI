using TradeApi.Dtos;

namespace PortfolioApi.Dtos;

public class PortfolioDto
{
    public string PortfolioName { get; set; } = string.Empty;
    public ICollection<TradeDto> Trades { get; set; } = new List<TradeDto>();
}