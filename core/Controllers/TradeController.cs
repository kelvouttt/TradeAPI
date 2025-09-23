using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TradeApi.Models;
using TradeApi.Mappings;
using TradeInterfaceApi.Data;
using Microsoft.EntityFrameworkCore;
using TradeRepositoryInterface;
using TradeApi.Repository;

namespace TradeInterfaceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradeController : ControllerBase
{
    private readonly ITradeRepository _repo;

    public TradeController(ITradeRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAllTrades()
    {
        var trades = _repo.GetAll();
        // var tradeDtos = trades.Select(trade => trade.ToDto()).ToList();

        return Ok(trades);
    }

    [HttpGet("{id}")]
    public IActionResult GetTrade(Guid id)
    {
        var trade = _repo.GetTrade(id);
        return Ok(trade);
    }

    [HttpPost]
    public IActionResult CreateTrade(Trade trade)
    {
        _repo.Add(trade);

        return Ok(trade);
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveTrade(Guid id)
    {
        try
        {
            var trade = _repo.GetTrade(id);
            if (trade == null)
            {
                return NotFound();
            }

            _repo.Delete(trade);

            return StatusCode(StatusCodes.Status204NoContent);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}