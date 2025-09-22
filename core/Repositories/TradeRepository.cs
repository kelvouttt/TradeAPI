using Microsoft.EntityFrameworkCore;
using TradeApi.Models;
using TradeInterfaceApi.Data;
using TradeRepositoryInterface;

namespace TradeApi.Repository;

public class TradeRepository : ITradeRepository
{
    private readonly TradeDbContext _context;

    public TradeRepository(TradeDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Trade> GetAll()
    {
        return _context
        .Trades
        .ToList();
    }

    public Trade? GetTrade(Guid id)
    {
        return _context.Trades.FirstOrDefault(t => t.Id == id);
    }

    public void Add(Trade trade)
    {
        _context.Trades.Add(trade);
    }

    public void Delete(Trade trade)
    {
        _context.Trades.Remove(trade);
    }
}