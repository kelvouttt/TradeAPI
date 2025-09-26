using Models.Domain.TradeAPI;
using Data.AppDbContext;
using Repositories.TradeAPIInterface;


namespace Repositories.TradeAPI;

public class TradeRepository : ITradeRepository
{
    private readonly AppDbContext _context;

    public TradeRepository(AppDbContext context)
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
        trade.Id = Guid.NewGuid();
        trade.TradeDate = DateTime.UtcNow;

        // Here, we are creating a custom TradeId which is different to the Guid of the trade. 
        // The TradeId is prefixed by the letter 'T' which is followed by 5 numbers incrementally.
        // In order to create that incremental mechanism, first we need to get the latest TradeId
        var lastTrade = _context.Trades.OrderByDescending(t => t.TradeId).FirstOrDefault();

        // We store the nextNumber value as placeholder.
        int nextNumber = 1;

        // Now we check if there is last trade / any trades in the database AND check if the length of the TradeId has a length longer than 1.
        if (lastTrade != null && lastTrade.TradeId.Length > 1)
        {
            // Substring of 1 cuts the prefix 'T' and leave the rest numbers (e.g., 00012 / 00421)
            string numberPart = lastTrade.TradeId.Substring(1);
            // int.TryParse will check if the input is a digit 0-9, and convert to integer stored as lastNumber
            // The increment is added in this if statement
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        // D stands for decimal, this will convert the number into string with (D) decimal digits prefix to the nextNumber variable. For example, if nextNumber = 99,  D5 will format it as as string '00099' (5)
        trade.TradeId = $"T{nextNumber:D5}";

        // Handle saving the object via repository
        _context.Trades.Add(trade);
        _context.SaveChanges();
    }

    public void Delete(Trade trade)
    {
        _context.Trades.Remove(trade);
        _context.SaveChanges();
    }
}