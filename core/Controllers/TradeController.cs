using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TradeApi.Models;
using TradeApi.Mappings;
using TradeInterfaceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace TradeInterfaceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradeController : ControllerBase
{
    private readonly TradeDbContext _context;

    public TradeController(TradeDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateTrade([FromBody] Trade trade)
    {
        trade.Id = Guid.NewGuid();
        trade.TradeDate = DateTime.UtcNow;

        // Get the last trades in database; sort by descending -> Get the first value on the sequence. 
        var lastTrade = _context.Trades
            .OrderByDescending(t => t.TradeId)
            .FirstOrDefault();

        // Set this value into 1 first
        int nextNumber = 1;

        // Perform conditional checks, if the below condition is not satisfied, the nextNumber remains 1 meaning there are no previous / existing trades in database
        if (lastTrade != null && lastTrade.TradeId.Length > 1)
        {
            string numberPart = lastTrade.TradeId.Substring(1);
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }

        trade.TradeId = $"T{nextNumber:D5}";

        _context.Trades.Add(trade);
        _context.SaveChanges();

        return Ok(trade.ToDto());
    }

    [HttpGet("{id}")]
    public IActionResult GetTradeById(Guid id)
    {
        var trade = _context.Trades.FirstOrDefault(t => t.Id == id);
        if (trade == null)
            return NotFound();

        return Ok(trade);
    }

    [HttpGet]
    public IActionResult GetAllTrades()
    {
        var trades = _context.Trades.Include(trade => trade.Portfolio).ToList();
        var tradeDtos = trades.Select(trade => trade.ToDto()).ToList();

        return Ok(tradeDtos);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTrade(Guid id)
    {
        try
        {
            var trade = _context.Trades.FirstOrDefault(t => t.Id == id);
            if (trade == null)
            {
                return NotFound($"Trade does not exist");
            }

            _context.Trades.Remove(trade);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status204NoContent, $"Trade {trade.TradeId} has been successfully deleted!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting trade.");
        }
        
    }
}