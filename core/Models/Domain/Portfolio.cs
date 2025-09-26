using Models.Domain.TradeAPI;

namespace Models.Domain.PortfolioAPI;

public class Portfolio
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string PortfolioName { get; set; } = string.Empty;
    public DateTime PortfolioCreation { get; set; } = DateTime.UtcNow;

    public ICollection<Trade> Trades { get; set; } = new List<Trade>();
}