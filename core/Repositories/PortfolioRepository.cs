using Microsoft.EntityFrameworkCore;
using Models.Domain.PortfolioAPI;
using Repositories.PortfolioAPIInterface;
using Data.AppDbContext;


namespace Repositories.PortfolioAPI;

public class PortfolioRepository : IPortfolioRepository
{
    private readonly AppDbContext _context;

    public PortfolioRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Portfolio> GetAll()
    {
        return _context
        .Portfolios
        .Include(p => p.Trades)
        .ThenInclude(t => t.Instrument)
        .ToList();
    }

    public Portfolio? GetPortfolio(Guid id)
    {
        return _context
        .Portfolios
        .Include(p => p.Trades)
        .ThenInclude(t => t.Instrument)
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