using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models;
using PortfolioRepositoryInterface;
using TradeInterfaceApi.Data;

namespace PortfolioApi.Repository;

public class PortfolioRepository : IPortfolioRepository
{
    private readonly TradeDbContext _context;

    public PortfolioRepository(TradeDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Portfolio> GetAll()
    {
        return _context
        .Portfolios
        .Include(p => p.Trades)
        .ToList();
    }

    public Portfolio? GetPortfolio(Guid id)
    {
        return _context.Portfolios
        .Include(p => p.Trades)
        .FirstOrDefault(p => p.Id == id);
    }

    public void Add(Portfolio portfolio)
    {
        _context.Portfolios.Add(portfolio);
        _context.SaveChanges();
    }

    public void Delete(Portfolio portfolio)
    {
        _context.Portfolios.Remove(portfolio);
        _context.SaveChanges();
    }
}