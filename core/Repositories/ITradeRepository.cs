using Models.Domain.TradeAPI;


namespace Repositories.TradeAPIInterface;

public interface ITradeRepository
{
    IEnumerable<Trade> GetAll();
    Trade? GetTrade(Guid id);
    void Add(Trade trade);
    void Delete(Trade trade);
}