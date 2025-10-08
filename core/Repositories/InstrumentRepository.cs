using Data.AppDbContext;
using Repositories.InstrumentAPIInterface;
using Models.Domain.InstrumentAPI;
using Microsoft.EntityFrameworkCore;


namespace Repositories.InterfaceAPI;

public class InstrumentRepository : IInstrumentRepository
{
    private readonly AppDbContext _context;

    public InstrumentRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Instrument> GetAll()
    {
        return _context
        .Instruments
        // This only includes the trade details, however does not include the portfolio that is related to the trade.
        .Include(i => i.Trades)
        // Therefore we use ThenInclude() to include the portfolio related to the trade.
        .ThenInclude(t => t.Portfolio)
        .ToList();
    }

    public Instrument? GetInstrument(Guid id)
    {
        return _context
        .Instruments
        .Include(i => i.Trades)
        .ThenInclude(t => t.Portfolio)
        .FirstOrDefault(i => i.Id == id);
    }

    public void Add(Instrument instrument)
    {
        _context.Instruments.Add(instrument);
        _context.SaveChanges();
    }

    public void Delete(Instrument instrument)
    {
        _context.Instruments.Remove(instrument);
        _context.SaveChanges();
    }
}