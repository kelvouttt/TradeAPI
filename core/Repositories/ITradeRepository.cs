using TradeApi.Models;

namespace TradeRepositoryInterface;

public interface ITradeRepository
{
    IEnumerable<Trade> GetAll();
    Trade? GetTrade(Guid id);
    void Add(Trade trade);
    void Delete(Trade trade);
}