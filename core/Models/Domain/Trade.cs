using Models.Domain.PortfolioAPI;

namespace Models.Domain.TradeAPI;

public class Trade
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string TradeId { get; set; } = string.Empty;
	public string Instrument { get; set; } = string.Empty;
	public decimal Quantity { get; set; }
	public decimal Price { get; set; }
	public DateTime TradeDate { get; set; } = DateTime.UtcNow;
	public string Counterparty { get; set; } = string.Empty;

	// This is the foreign key pointing to Id field in Portfolio model ,it needs to have the same type. 
	public Guid PortfolioId { get; set; }
	public Portfolio? Portfolio { get; set; }
}