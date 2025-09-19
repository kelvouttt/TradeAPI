namespace TradeApi.Dtos;

public class TradeDto
{
    public string? TradeId { get; set; }
    public string? Instrument { get; set; }
    public decimal? Quantity { get; set; }
    public decimal? Price { get; set; }
    public string? Counterparty { get; set; }
    public string? PortfolioName { get; set; }
}